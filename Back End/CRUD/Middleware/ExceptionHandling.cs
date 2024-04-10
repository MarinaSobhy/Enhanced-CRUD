using Microsoft.AspNetCore.Mvc;
using System;

namespace CRUD.Middleware
{
    public class ExceptionHandling
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandling> _logger;

        public ExceptionHandling( RequestDelegate next, ILogger<ExceptionHandling> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred: {Message}", ex.Message);
                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Server Error"
                };
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }
    }
}
