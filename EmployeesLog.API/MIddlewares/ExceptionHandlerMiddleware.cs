﻿using System.Net;

namespace EmployeesLog.API.MIddlewares
{
    public class ExceptionHandlerMiddleware 
    {
        private readonly ILogger<ExceptionHandlerMiddleware> logger;
        private readonly RequestDelegate next;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }


        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception e)
            {
                var errorId = Guid.NewGuid();
                //Log this exception.
                logger.LogError(e, $"{errorId} : {e.Message}");

                //return a custom error response.
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errorId,
                    ErrorMessage = "Something went wrong"
                };

                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
