using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace ILBLI_WebAPI
{
    public class Program
    {
        //core 就是一个控制台应用程序，main就是整个程序的入口
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        /// <summary>
        /// 这个就是起到IIS的  请求监听---转发请求---相应请求 的功能
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                //注册log4服务
                .ConfigureLogging((context, loggingBuilder) => {
                    loggingBuilder.AddFilter("System", LogLevel.Warning);
                    loggingBuilder.AddFilter("Microsoft", LogLevel.Warning);
                    loggingBuilder.AddLog4Net();
                });
    }
}
