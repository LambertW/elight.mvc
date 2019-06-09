using Elight.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elight.IService
{
    public partial interface IUserLogOnService : IBaseService<Sys_UserLogOn, Guid>
    {
        /// <summary>
        /// 根据用户ID查询用户登陆信息。
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        Sys_UserLogOn GetByAccount(Guid userId);

        /// <summary>
        /// 更新登陆次数、上次访问时间、最后访问时间。
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int UpdateLogin(Sys_UserLogOn model);

        /// <summary>
        /// 更新密保问题、同时登陆、IP过滤、主题语言。
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int UpdateInfo(Sys_UserLogOn model);

        /// <summary>
        /// 修改密码。 
        /// </summary>
        /// <param name="model">用户登录模型</param>
        /// <returns></returns>
        bool ModifyPwd(Sys_UserLogOn model);
    }
}
