using MediatR;
using System.Net;
using System.Text.Json;
using ZettelKasten.Models.API;

namespace ZettelKasten.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        //catch (ParameterValidationException ex)
        //{
        //    await GetResponse(context, ex?.Errors, HttpStatusCode.BadRequest);
        //}
        catch (Exception ex)
        {
            await GetResponse(context, [ex?.Message ?? string.Empty], HttpStatusCode.InternalServerError);
        }
    }

    private Task GetResponse(HttpContext context, string[] messages, HttpStatusCode statusCode)
    {
        var response = context.Response;
        response.ContentType = "application/json; charset=windows-1251";
        response.StatusCode = (int)statusCode;

        string result = JsonSerializer.Serialize(Result<Unit>.Failure(messages));

        return response.WriteAsync(result);
    }
}
