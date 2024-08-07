using BookingSystem.Domain.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookingSystem.Application.Exceptions
{
    public sealed class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next(context);
			}
			catch (BookingSystemException ex)
			{

				context.Response.StatusCode = 400;
				context.Response.Headers.Add("content-type", "application/json");

				var errorCode = ex.GetType().Name;	
				var json = JsonSerializer.Serialize(new { errorCode , ex.Message });
				await context.Response.WriteAsync(json);
			}
        }
    }
}
