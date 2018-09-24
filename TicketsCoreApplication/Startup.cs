using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace TicketsCoreApplication
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
            services.AddTransient<Services.ITicketsService, Services.Implementations.TicketsService>();
            services.AddTransient<Repositories.ITicketsRepository, Repositories.Implementations.TicketsRepository>();


            services.AddTransient<Services.IStatusesService, Services.Implementations.StatusesService>();
            services.AddTransient<Repositories.IStatusesRepository, Repositories.Implementations.StatusesRepository>();

            services.AddTransient<Services.ICategoriesService, Services.Implementations.CategoriesService>();
            services.AddTransient<Repositories.ICategoriesRespository,Repositories.Implementations.CategoriesRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
