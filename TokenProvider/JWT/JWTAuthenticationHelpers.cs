using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using TokenProvider.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;

namespace TokenProvider.JWT
{
    public static class JWTAuthenticationHelpers
    {
        /// <summary>
        /// UN AUTHORIZED USER
        /// </summary>
        private const string UNAUTHORIZEDUSER = "Invalid Token";

        /// <summary>
        /// Protect WebApi With JWT
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddProtectWebApiWithJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var objReturnBaseModel = new ReturnBaseModel<string>();
            var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("AppSettings:JWTSecret"));

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            // Change the authentication configuration  to accommodate the Microsoft identity platform endpoint.
            services.Configure<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                // When an access token for our own Web API is validated, we add it to MSAL.NET's cache so that it can
                // be used from the controllers.
                options.Events = new JwtBearerEvents
                {
                    OnChallenge = context =>
                    {
                        context.HandleResponse();

                        objReturnBaseModel.errorCode = HttpStatusCode.Unauthorized.ToString();
                        objReturnBaseModel.errorMessage = UNAUTHORIZEDUSER;
                        var jsonObject = JsonSerializer.Serialize(objReturnBaseModel);
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        return context.Response.WriteAsync(jsonObject, Encoding.UTF8);
                    },
                    OnTokenValidated = async context =>
                    {
                        await Task.FromResult(0).ConfigureAwait(true);
                    }
                };

                // If you want to debug, or just understand the JwtBearer events, uncomment the following line of code
                options.Events = JwtBearerMiddlewareDiagnostics.Subscribe(options.Events);
            });
            return services;
        }
    }
}
