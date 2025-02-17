﻿using Microsoft.AspNetCore.Diagnostics;
using Serializer.Exceptions.Common;
using System.Net;

namespace Serializer.Middlewares;

public static class GlobalExceptionHandler
{
    public static IApplicationBuilder AddExceptionHandlerService(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(error =>
        {
            error.Run(async context =>
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                int statusCode = (int)HttpStatusCode.InternalServerError;
                string message = "Internal Server Error";

                if (contextFeature is not null)
                {
                    if (contextFeature.Error is IBaseException baseException)
                    {
                        var error = contextFeature.Error;
                        statusCode = baseException.StatusCode;
                        message = error.Message;

                    }
                }
                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsJsonAsync(new ResultDto(statusCode, false, message));
            });
        });

        return app;
    }
}
