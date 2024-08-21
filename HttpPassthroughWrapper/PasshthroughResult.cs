namespace HttpPassthroughWrapper;

public class PasshthroughResult<T>
{
    public T? SucessResult { get; set; }

    public IResult? ErrorResult { get; set; }
}