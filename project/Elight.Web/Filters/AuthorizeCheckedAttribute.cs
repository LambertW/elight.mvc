using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Elight.Infrastructure;
using Elight.IService;
using Elight.Entity;

namespace Elight.Web.Filters
{
    /// <summary>
    /// 表示一个特性，该特性用于标识用户是否有访问权限。
    /// </summary>
    public class AuthorizeCheckedAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 是否忽略权限检查。
        /// </summary>
        public bool Ignore { get; set; }

        private IPermissionService _permissionService;

        public AuthorizeCheckedAttribute(bool ignore = false)
        {
            Ignore = ignore;
            _permissionService = AutoFacConfig.Resolve<IPermissionService>();
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Ignore)
            {
                return;
            };
            var userId = OperatorProvider.Instance.Current.UserId;
            var action = HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();
            var requestMethod = HttpContext.Current.Request.ServerVariables["REQUEST_METHOD"].ToString();

            var accessPermission = _permissionService.ActionValidate(Guid.Parse(userId), action);
            if (accessPermission == null)
            {
                StringBuilder script = new StringBuilder();
                script.Append("<script>alert('对不起，您没有权限访问当前页面。');</script>");
                filterContext.Result = new ContentResult() { Content = script.ToString() };
            }

            LogOperateAction(accessPermission, requestMethod);
        }

        private void LogOperateAction(Sys_Permission permission, string requestMethod)
        {
            switch (permission.Type)
            {
                case 0:
                    if (requestMethod.Equals("GET", StringComparison.InvariantCultureIgnoreCase))
                    {
                        LogHelper.Write(Level.Info, permission.Name, "访问成功", OperatorProvider.Instance.Current.Account, OperatorProvider.Instance.Current.RealName);
                    }
                    break;

                case 1:
                    if(requestMethod.Equals("POST", StringComparison.InvariantCultureIgnoreCase))
                    {
                        LogHelper.Write(Level.Info, permission.Name, "点击保存", OperatorProvider.Instance.Current.Account, OperatorProvider.Instance.Current.RealName);
                    }
                    break;

                default:
                    break;
            }
        }
    }
}