using System.Net.Mime;
using System.Text.Json;

namespace HttpPassthroughWrapper.CustomResultObject;

public class PassthroughHandler<T>(IServiceProvider serviceProvider) : IPassthroughHandler<T>
    where T : IClient
{
    public async Task<PasshthroughResult<TResult>> HandleAsync<TResult>(Func<T, Task<TResult>> operation)
    {
        var service = serviceProvider.GetService<T>();
        if (service is null)
            throw new Exception("Failure");

        try
        {
            TResult requestResult = await operation(service);

            return new PasshthroughResult<TResult>
            {
                SucessResult = requestResult
            };
        }
        catch (HttpRequestException e)
        {
            return new PasshthroughResult<TResult>
            {
                ErrorResult = Results.StatusCode(Convert.ToInt32(e.StatusCode!))
            };
        }
        catch (Exception e)
        {
            return new PasshthroughResult<TResult>
            {
                ErrorResult = Results.StatusCode(500)
            };
        }
    }

    public async Task<PasshthroughResult<TResult>> HandleAsync<TRequest, TResult>(Func<T, Task<TResult>> operation,
        TRequest? request)
    {
        var service = serviceProvider.GetService<T>();
        if (service is null)
            throw new Exception("Failure");

        try
        {
            TResult requestResult = await operation(service);

            return new PasshthroughResult<TResult>
            {
                SucessResult = requestResult
            };
        }
        catch (HttpRequestException e)
        {
            return new PasshthroughResult<TResult>
            {
                ErrorResult = Results.Content(content: JsonSerializer.Serialize(request),
                    contentType: MediaTypeNames.Application.Json, statusCode: Convert.ToInt32(e.StatusCode!))
            };
        }
        catch (Exception e)
        {
            return new PasshthroughResult<TResult>
            {
                ErrorResult = Results.StatusCode(500)
            };
        }
    }
}