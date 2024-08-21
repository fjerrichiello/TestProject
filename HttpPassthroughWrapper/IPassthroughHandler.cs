namespace HttpPassthroughWrapper;

public interface IPassthroughHandler<out T>
{
    Task<PasshthroughResult<TResult>> HandleAsync<TResult>(Func<T, Task<TResult>> operation);

    Task<PasshthroughResult<TResult>> HandleAsync<TRequest, TResult>(Func<T, Task<TResult>> operation,
        TRequest request);
}