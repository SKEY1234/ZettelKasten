namespace ZettelKasten.Models.Responses;

public class Result<T>
{
    internal Result(bool isSuccess, IEnumerable<string> errors, T value)
    {
        IsSuccess = isSuccess;
        Errors = errors.ToArray();
        Value = value;
    }

    internal Result(bool isSuccess, IEnumerable<string> errors)
    {
        IsSuccess = isSuccess;
        Errors = errors.ToArray();
    }

    public bool IsSuccess { get; set; } = default!;
    public T Value { get; set; } = default!;

    public string[] Errors { get; set; }

    public static Result<T> Success()
    {
        return new Result<T>(true, Array.Empty<string>());
    }

    public static Result<T> Success(T value)
    {
        return new Result<T>(true, Array.Empty<string>(), value);
    }

    public static Result<T> Failure(IEnumerable<string> errors)
    {
        return new Result<T>(false, errors);
    }

    public static Result<T> Failure(string error)
    {
        return new Result<T>(false, new string[] { error });
    }
}
