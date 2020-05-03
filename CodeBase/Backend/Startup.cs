using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Interfaces;
using Backend.Mocks;
using Backend.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Add MockedServiced if in Debug, real services if not
#if DEBUG
            AddMockedServices(services);
#else
            AddRealServices(services);          
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Helper methods that registers services for productions.
        /// </summary>
        /// <param name="services"></param>
        private void AddRealServices(IServiceCollection services)
        {
            services.AddTransient<INavAuthService, NavAuthService>();
            services.AddTransient<INavBasketsService, NavBasketsService>();
            services.AddTransient<INavProductsService, NavProductsService>();
            services.AddTransient<INavTransactionsService, NavTransactionsService>();
            services.AddTransient<INavUsersService, NavUsersService>();
        }

        /// <summary>
        /// Helper methods that registers Mocked services for Debug
        /// </summary>
        /// <param name="services"></param>
        private void AddMockedServices(IServiceCollection services)
        {
            services.AddTransient<INavAuthService, NavAuthServiceMock>();
            services.AddTransient<INavBasketsService, NavBasketsServiceMock>();
            services.AddTransient<INavProductsService, NavProductsServiceMock>();
            services.AddTransient<INavTransactionsService, NavTransactionsServiceMock>();
            services.AddTransient<INavUsersService, NavUsersServiceMock>();
        }
    }
}
