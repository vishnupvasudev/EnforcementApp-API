#region Included Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enforcement.DAL;
using Enforcement.DAL.Dapper;
using Microsoft.Extensions.DependencyInjection;
using Utilities;
using Utilities.Interfaces;
#endregion Included Namespaces

namespace Enforcement.BLL.DI
{
    #region IServiceCollectionExtension
    /// <summary>
    /// IServiceCollectionExtension
    /// </summary>
    public static class IServiceCollectionExtension
    {
        /// <summary>
        /// AddRepository
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IRepository, DapperRepository>();
            return services;
        }
    }
    #endregion IServiceCollectionExtension
}
