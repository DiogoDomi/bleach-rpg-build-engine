using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using BuildCalculator.Configuration;
using BuildCalculator.Data;
using BuildCalculator.Data.Parsers.Loaders.Csv;

namespace BuildCalculator;

public class Program
{
    public static void Main()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true)
            .Build();

        var services = new ServiceCollection();

        services.Configure<GameDirectoriesConfig>(config.GetSection("GameDirectories"));
        services.AddSingleton<GameDirectoriesConfig>(provider =>
        {
            var config = provider.GetRequiredService<IOptions<GameDirectoriesConfig>>();
            var directories = config.Value;

            if (string.IsNullOrWhiteSpace(directories.CsvDirPath))
            {
                Console.WriteLine("Error: CsvDirPath was not configured");
                Environment.Exit(1);
                return null!;
            }

            return directories;
        });

        services.AddRepository(config => CsvLookupLoader.LoadRepository(config.CsvDirPath));
        services.AddRepository(config => CsvCharacterLoader.LoadRepository(config.CsvDirPath));
        services.AddRepository(config => CsvWeaponLoader.LoadRepository(config.CsvDirPath));
        services.AddRepository(config => CsvSkillLoader.LoadRepository(config.CsvDirPath));
        services.AddRepository(config => CsvBoundaryLoader.LoadRepository(config.CsvDirPath));
        services.AddRepository(config => CsvWeaponStampLoader.LoadRepository(config.CsvDirPath));
        services.AddRepository(config => CsvCoreStampLoader.LoadRepository(config.CsvDirPath));
        services.AddRepository(config => CsvSetStampLoader.LoadRepository(config.CsvDirPath));
        services.AddRepository(config => CsvItemLoader.LoadRepository(config.CsvDirPath));
        services.AddRepository(config => CsvGameConfigLoader.LoadRepository(config.CsvDirPath));

        services.AddSingleton<GameData>();

        var serviceProvider = services.BuildServiceProvider();
        var gameData = serviceProvider.GetRequiredService<GameData>();

        Console.WriteLine("It Worked!");
    }
}

