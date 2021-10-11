#region Included Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Enforcement.BLL.DI;
using Enforcement.BLL.Implementation;
using Enforcement.BLL.Implementation.Account;
using Enforcement.BLL.Implementation.Enforcement;
using Enforcement.BLL.Interface;
using Enforcement.BLL.Interface.Account;
using Enforcement.BLL.Interface.Enforcement;
using EnforcementAppAPI.Common;
using EnforcementAppAPI.Models.Common;
using KeyVault;
using KeyVault.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TokenProvider;
using TokenProvider.Interfaces;
using Utilities.ExceptionManagement;
using Utilities.Interfaces;
#endregion Included Namespaces

namespace EnforcementAppAPI
{
    #region Startup
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        #region Startup
        /// <summary>
        /// Startup
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        #endregion Startup

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        #region ConfigureServices
        /// <summary>
        /// ConfigureServices
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("AppSettings:JWTSecret"));

            services.AddControllers();
            services.AddSingleton(Configuration);
            services.AddRepository();
            services.AddDataProtection();
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", ////Name the security scheme
                         new OpenApiSecurityScheme
                         {
                             Description = "JWT Authorization header using the Bearer scheme.",
                             Type = SecuritySchemeType.Http, ////We set the scheme type to http since we're using bearer authentication
                             Scheme = "bearer" ////The name of the HTTP Authorization scheme to be used in the Authorization header. In this case "bearer".
                         });
                c.OperationFilter<Filters.AuthorizationHeaderParameterOperationFilter>();
            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                x.Events = new JwtBearerEvents();
                x.Events.OnChallenge = context =>
                {
                    context.HandleResponse();

                    var objResponseModal = new ReturnBaseModel<string>();
                    objResponseModal.InvalidToken("Invalid AccessToken. Authentication failed");
                    var jsonObject = JsonSerializer.Serialize(objResponseModal);
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

                    return context.Response.WriteAsync(jsonObject, Encoding.UTF8);
                };
            });

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                 .RequireAuthenticatedUser()
                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
                config.Filters.Add(typeof(Filters.ExceptionFilter));
            });

            services.AddSingleton<IKeyValueProvider, WebConfigKeyVault>();
            services.AddSingleton<ITokenProvider, JWTService>();
            services.AddSingleton<ILog, NLogExceptionManagment>();

            services.AddScoped<IUser, UserBLL>();
            services.AddScoped<IAuthentication, AuthenticationBLL>();
            services.AddScoped<IEnforcement, EnforcementBLL>();
            services.AddScoped<ICommon, CommonBLL>();
        }
        #endregion ConfigureServices

        #region Configure
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        #endregion Configure
    }
    #endregion Startup
}
