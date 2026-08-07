namespace BuildCalculator.Core;

public readonly record struct ResultData<T>(
        T Item,
        string Message,
        bool IsSuccess,
        ResultError Error
)
{
    public static ResultData<T> Ok(T item)
    {
        return new ResultData<T>(item, string.Empty, true, ResultError.None);
    }

    public static ResultData<T> Fail(ResultError error, string message)
    {
        return new ResultData<T>(default!, message, false, error);
    }
};

