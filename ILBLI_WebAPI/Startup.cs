using ILBLI.Unity;
using ILBLI.Unity.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ILBLI_WebAPI
{
    /// <summary>
    /// 自定义配置启动服务与管道处理类
    /// </summary>
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        } 

        // This method gets called by the runtime. Use this method to add services to the container. 
        /// <summary>
        /// 注入服务【这个IServiceCollection是core框架内置的IOC容器，它内置了一些服务功能，比如swagger,log4...我们后面将把它替换成自己的IOC容器】
        /// </summary>
        /// <param name="services"></param>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //自己封装的swagger初始化注入
            services.AddSwaggerInit();
             
            //配置全局跨域
            services.AddCors(cros =>
            {
                cros.AddPolicy("any", builder =>
                {
                    builder.AllowAnyHeader()
                           .AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowCredentials();
                });
            });

            //配置自定义的AutoMapper
            services.AddAutoMapperInit();

            //配置拦截器层
            services.AddFilterInit();

            //将IOC容器换成自定义的容器
            return services.AddAutofacInit(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 自定义请求管道内容
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
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
            //启用Https
            app.UseHttpsRedirection();
            //启用静态文件
            app.UseStaticFiles();
            //添加自己封装的swaggerUI
            app.UseSwaggerUIInit();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}");
            });

        }
    }
}
