using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TimespanBug.GraphQL;
using TimespanBug.Store;
using GraphQL.Types;
using GraphQL;

namespace TimespanBug
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
            services
                .AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService))
                .AddScoped<IDocumentExecuter, DocumentExecuter>()
                .AddScoped<ISchema, MySchema>()
                .AddScoped<MyQuery>()
                .AddScoped<MyMutation>()
                .AddScoped<ItemInputType>()
                .AddScoped<ItemType>()
                .AddSingleton<ItemStore>()
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions {
                    Path = "/playground"
                });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
