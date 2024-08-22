namespace HttpPassthroughWrapper.WithMapper;

public interface IPassthroughHandlerWithMapper<out T>
    where T : IClient
{
    Task<IResult> HandleAsync<TApiResult, TMapResult>(Func<T, Task<TApiResult>> operation);

    Task<IResult> HandleAsync<TRequest, TApiResult, TMapResult>(Func<T, Task<TApiResult>> operation,
        TRequest request);
}