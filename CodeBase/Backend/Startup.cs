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
            try
            {
                Configuration = configuration;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
          
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                services.AddControllers();

                //Add MockedServiced if in Debug, real services if not
#if DEBUG
                AddMockedServices(ref services); //Do i need ref mb here?
#else
            AddRealServices(ref services);          
#endif
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }     
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            try
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

                app.UseHttpsRedirection();

                app.UseRouting();

                //app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
         
        }

        /// <summary>
        /// Helper methods that registers services for productions.
        /// </summary>
        /// <param name="services"></param>
        private void AddRealServices(ref IServiceCollection services)
        {
            try
            {
                services.AddTransient<INavProductsService, NavProductsService>();
                services.AddTransient<INavTransactionsService, NavTransactionsService>();
                services.AddTransient<INavBasketsService, NavBasketsService>();
                services.AddTransient<INavUsersService, NavUsersService>();
                services.AddTransient<INavAuthService, NavAuthService>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                throw;
            }        
        }

        /// <summary>
        /// Helper methods that registers Mocked services for Debug
        /// </summary>
        /// <param name="services"></param>
        private void AddMockedServices(ref IServiceCollection services)
        {
            try
            {
                services.AddTransient<INavAuthService, NavAuthServiceMock>();
                services.AddTransient<INavBasketsService, NavBasketsServiceMock>();
                services.AddTransient<INavProductsService, NavProductsServiceMock>();
                services.AddTransient<INavTransactionsService, NavTransactionsServiceMock>();
                services.AddTransient<INavUsersService, NavUsersServiceMock>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                throw;
            }        
        }
    }
}
