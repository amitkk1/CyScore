using CyScore.Data.Interfaces;
using CyScore.Data.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyScore.Data
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCyscoreDataServices(this IServiceCollection services)
        {
            services.AddScoped<IUserDataAccessService, UserDataAccessService>();
        }
    }
}
