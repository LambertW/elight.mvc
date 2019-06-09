using Elight.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elight.IService
{
    public partial interface IUserRoleRelationService : IBaseService<Sys_UserRoleRelation, Guid>
    {
        /// <summary>
        /// 根据用户ID获取角色集合。
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        List<Sys_UserRoleRelation> GetList(Guid userId);

        /// <summary>
        /// 给用户配置角色信息。   
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="roleIds">角色ID集合</param>
        void SetRole(Guid userId, params Guid[] roleIds);
    }
}
