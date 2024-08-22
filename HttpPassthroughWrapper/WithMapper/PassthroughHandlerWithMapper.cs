using System.Net.Mime;
using System.Text.Json;

namespace HttpPassthroughWrapper.WithMapper;

public class PassthroughHandlerWithMapper<T>(IServiceProvider serviceProvider)
    : IPassthroughHandlerWithMapper<T>
    where T : IClient
{
    public async Task<IResult> HandleAsync<TApiResult, TMapResult>(Func<T, Task<TApiResult>> operation)
    {
        var service = serviceProvider.GetService<T>();
        if (service is null)
            throw new Exception("Service not found");

        var mapper = serviceProvider.GetService<IMapper<TApiResult, TMapResult>>();
        if (mapper is null)
            throw new Exception("Mapper not found");

        try
        {
            // Perform the service operation
            TApiResult requestResult = await operation(service);

            // Use the mapper to transform the result
            TMapResult mappedResult = mapper.Map(requestResult);

            // Return the transformed result inside the PasshthroughResult
            return Results.Ok(mappedResult);
        }
        catch (HttpRequestException e)
        {
            // Handle HttpRequestException with error result
            return Results.StatusCode(Convert.ToInt32(e.StatusCode!));
        }
        catch (Exception e)
        {
            // Handle generic exception

            return Results.StatusCode(500);
        }
    }

    public async Task<IResult> HandleAsync<TRequest, TApiResult, TMapResult>(Func<T, Task<TApiResult>> operation,
        TRequest request)
    {
        var service = serviceProvider.GetService<T>();
        if (service is null)
            throw new Exception("Service not found");

        var mapper = serviceProvider.GetService<IMapper<TApiResult, TMapResult>>();
        if (mapper is null)
            throw new Exception("Mapper not found");

        try
        {
            // Perform the service operation
            TApiResult requestResult = await operation(service);

            // Use the mapper to transform the result
            TMapResult mappedResult = mapper.Map(requestResult);

            // Return the transformed result inside the PasshthroughResult
            return Results.Ok(mappedResult);
        }
        catch (HttpRequestException e)
        {
            // Handle HttpRequestException with error result
            return Results.Content(content: JsonSerializer.Serialize(request),
                contentType: MediaTypeNames.Application.Json, statusCode: Convert.ToInt32(e.StatusCode!));
        }
        catch (Exception e)
        {
            // Handle generic exception

            return Results.StatusCode(500);
        }
    }
}