using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.DependencyInjection;

using MMC.Web.Helper.Filter;

namespace MMC.Web.Helper.Middleware
{
    /// <summary>
    /// swagger自定义中间件
    /// </summary>
    public static class SwaggerMiddleware
    {
        /// <summary>
        /// swagger自定义配置
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblyString">枚举所在的程序集名称</param>
        /// <returns></returns>
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, string assemblyString)
        {
            services.AddSwaggerGen(options =>
            {
                if (string.IsNullOrEmpty(assemblyString))
                    // 使swagger枚举注释显示 参数：枚举所在的程序集名称
                    options.DocumentFilter<SwaggerEnumDocumentFilter>(new object[] { assemblyString });
            });

            return services;
        }
    }
}
