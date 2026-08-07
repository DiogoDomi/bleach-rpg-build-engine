using Microsoft.Extensions.DependencyInjection;
using BuildCalculator.Core;
namespace BuildCalculator.Configuration;

public static class ServiceCollectionExtensions
{
    public static void AddRepository<TRepo>(
            this IServiceCollection services,
            Func<GameDirectoriesConfig, ResultData<TRepo>> loadAction) where TRepo : class
    {
        services.AddSingleton<TRepo>(provider =>
        {
            var config = provider.GetRequiredService<GameDirectoriesConfig>();
            var loader = loadAction(config);

            if (!loader.IsSuccess)
            {
                Console.WriteLine($"Error loading {typeof(TRepo).Name}: {loader.Message}");
                Environment.Exit(1);
                return null!;
            }

            return loader.Item!;
        });
    }
}

