using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ILBLI.Unity
{
    public class AuthHandler : IAuthenticationHandler, IAuthenticationSignInHandler, IAuthenticationSignOutHandler
    {
        private AuthenticationScheme _Scheme;
        private HttpContext _Context;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="scheme"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task InitializeAsync(AuthenticationScheme scheme, HttpContext context)
        {
            this._Scheme = scheme;
            this._Context = context;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 实现登录[往数据库写入该票据信息，同时写入缓存]
        /// </summary>
        /// <param name="user"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        public Task SignInAsync(ClaimsPrincipal user, AuthenticationProperties properties)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 实现注销[将数据库当前票据进行过期，同时移除缓存]
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        public Task SignOutAsync(AuthenticationProperties properties)
        { 
            throw new NotImplementedException();
        }
        /// <summary>
        /// 身份认证
        /// </summary>
        /// <returns></returns>
        public Task<AuthenticateResult> AuthenticateAsync()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 未登录，要求用去登录[未登录处理]
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        public Task ChallengeAsync(AuthenticationProperties properties)
        {
            //跳转到登陆页
            this._Context.Response.Redirect("/login");
            return Task.CompletedTask;
        }
        /// <summary>
        /// 无权限处理[返回401无权限错误信息]
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        public Task ForbidAsync(AuthenticationProperties properties)
        {
            this._Context.Response.StatusCode = 401;
            return Task.CompletedTask;
        }
      
      
    }
}
