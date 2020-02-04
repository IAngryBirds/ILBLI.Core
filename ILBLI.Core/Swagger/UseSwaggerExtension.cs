using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ILBLI.Unity.Swagger
{
    public static class UseSwaggerExtension
    {

        public static IApplicationBuilder UseSwaggerUIInit(this IApplicationBuilder app)
        {
            //启用中间件服务生成swagger作为json的终结点
            app.UseSwagger();
            //启用中间件服务对swagger-ui，制定Swagger Json终结点
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); 
            });

            return app;
        }

        public static IServiceCollection AddSwaggerInit(this IServiceCollection services)
        {
            //注册Swagger生成器，定义一个和多个Swagger文档
            services.AddSwaggerGen(c => { 
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "MY API",
                    Description = "ASP.NET Core Web API",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "ilbli",
                        Email = "757102006@qq.com",
                        Url = ""
                    },
                    License = new License
                    {
                        Name = "许可证名字",
                        Url = ""
                    }
                });
                // 为 Swagger JSON and UI设置xml文档注释路径
                var basePath = Path.GetDirectoryName(typeof(UseSwaggerInit).Assembly.Location);//获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）
                var xmlPath = Path.Combine(basePath, "ILBLI_WebAPI.xml");
                c.IncludeXmlComments(xmlPath);
            });
            return services;
        }

    }
}
