using Elight.Entity;
using Elight.Entity.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elight.IRepository
{
    public partial interface IPermissionRepository : IBaseRepository<Sys_Permission, Guid>
    {
        /// <summary>
        /// 分页获取权限列表。
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="keyWord">编码或名称</param>
        /// <returns></returns>
        Page<Sys_Permission> GetList(int pageIndex, int pageSize, string keyWord);

        /// <summary>
        /// 获取子级权限数量。
        /// </summary>
        /// <param name="parentId">父级权限ID</param>
        /// <returns></returns>
        long GetChildCount(Guid parentId);
    }
}
