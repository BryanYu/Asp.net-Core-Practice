using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Middleware
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            #region app.Run
            //// app.Run 會中止Request Pipeline
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello From App.Run MiddleWare");
            //});

            ////下面的BeforeMiddleware01不會執行
            //app.Use(
            //    async (context, next) =>
            //    {
            //        Console.WriteLine("BeforeMiddleware01");
            //        await next.Invoke();
            //        Console.WriteLine("AfterMiddleware01");
            //    });

            #endregion


            #region app.Use
            //app.Use 會將要求傳至下一個Middleware
            // 以下設定呼叫的順序會是 BeforeMiddleware01 -> BeforeMiddleware02 ->
            //                      AfterMiddleware02 -> AfterMiddleware01
            //app.Use(
            //    async (context, next) =>
            //    {
            //        Console.WriteLine("BeforeMiddleware01");
            //        await next.Invoke();
            //        Console.WriteLine("AfterMiddleware01");
            //    });

            //app.Use(
            //    async (context, next) =>
            //    {
            //        Console.WriteLine("BeforeMiddleware02");
            //        await next.Invoke();
            //        Console.WriteLine("AfterMiddleware02");
            //    });

            #endregion

            #region app.Map
            // app.Map 是app.Run的擴充，可以根據route路徑來套用app.Run的MiddleWare 

            app.Map("/map1",
                config =>
                {
                    config.Run(async (context) =>
                    {
                        await context.Response.WriteAsync("Map Test 1");
                    });
                });


            app.Map("/map2",
                config =>
                {
                    config.Run(async (context) =>
                    {
                        await context.Response.WriteAsync("Map Test 2");
                    }); 
                });

            #endregion

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            
           
        }
    }
}
