using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace ILBLI.Unity
{
    /// <summary>
    /// 第一层（Conntroller实例化之前）[这个是MVC时代的验证体系在Core下有了全新的认证模式]
    /// </summary>
    public class AuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private readonly ILogger<AuthorizationFilterContext> _Logger;

        public AuthorizationAttribute(ILogger<AuthorizationFilterContext> logger)
        {
            this._Logger = logger;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _Logger.LogWarning("第一层权限拦截器--Controller实例化之前");
        }


    }
}
