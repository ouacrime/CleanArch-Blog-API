using AutoMapper;
using CleanArchi.Domain.Repository;
using CleanArchi.Infra.Data;
using CleanArchi.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchi.Infra
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<BlogDbContext>(options =>
                    
            
            {
                options.UseSqlite(configuration.GetConnectionString("BlougdbContext") ??
                    throw new InvalidOperationException("connnection string 'BlougdbContext not found'"));
                    
            
            
            });
            services.AddTransient<IBlogRepository, BlogRepository>();
            return services;
        
        }



    }
}
