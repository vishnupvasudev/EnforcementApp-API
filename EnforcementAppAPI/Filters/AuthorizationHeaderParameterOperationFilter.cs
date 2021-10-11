#region Included Namespaces
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
#endregion Included Namespaces

namespace EnforcementAppAPI.Filters
{
    #region AuthorizationHeaderParameterOperationFilter
    /// <summary>
    /// AuthorizationHeaderParameterOperationFilter
    /// </summary>
    public class AuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        #region Apply
        /// <summary>
        /// Apply
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var isAuthorized = (!context.MethodInfo.GetCustomAttributes(true).Any(x => x is AllowAnonymousAttribute) &&
                !context.MethodInfo.DeclaringType.GetCustomAttributes(true).Any(x => x is AllowAnonymousAttribute));

            if (!isAuthorized)
            {
                return;
            }

            operation.Responses.TryAdd("401", new OpenApiResponse { Description = "Unauthorized" });
            operation.Responses.TryAdd("403", new OpenApiResponse { Description = "Forbidden" });

            var jwtbearerScheme = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            };

            operation.Security = new List<OpenApiSecurityRequirement>
               {
                   new OpenApiSecurityRequirement
                   {
                       [jwtbearerScheme] = new string[] { }
                   }
               };
        }
        #endregion Apply
    }
    #endregion AuthorizationHeaderParameterOperationFilter
}
