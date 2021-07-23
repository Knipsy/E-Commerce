using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using API.Errors;
using Microsoft.AspNetCore.Http;
using Type = Core.Entities.Identity.Type;

namespace API.Middleware
{
    public class SecurityMiddleware
    {
        private readonly RequestDelegate _next;
        public SecurityMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            if (context.Request.Path.Value.StartsWith("/api/admin/"))
            {
                var type = context.User?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value;
                var role = (Type)Enum.Parse(typeof(Type), type ?? string.Empty);
                if ((role != Type.Admin))
                {
                    var json = JsonException(context);
                    await context.Response.WriteAsync(json);
                }
                else
                {
                    await _next(context);
                }
            }
            else
            {
                await _next(context);
            }


        }

        private static string JsonException(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new ApiResponse(401, "Bu sayfaya ulaşmak için gerekli yetkiye sahip değilsiniz.");
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var json = JsonSerializer.Serialize(response, options);
            return json;
        }
    }
}
