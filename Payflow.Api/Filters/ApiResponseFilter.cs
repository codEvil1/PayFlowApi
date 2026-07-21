using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PayFlow.Application.Common.Responses;

namespace PayFlow.Api.Filters;

public class ApiResponseFilter : IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (context.Result is ObjectResult objectResult)
        {
            var value = objectResult.Value;

            if (value != null)
            {
                var type = value.GetType();

                if (!(type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ApiResponse<>)))
                {
                    var responseType = typeof(ApiResponse<>).MakeGenericType(type);
                    var method = responseType.GetMethod(nameof(ApiResponse<>.SuccessResponse));

                    var response = method!.Invoke(
                        null,
                        [
                            value,
                            "Operação realizada com sucesso."
                        ]);

                    objectResult.Value = response;
                }
            }
        }

        await next();
    }
}