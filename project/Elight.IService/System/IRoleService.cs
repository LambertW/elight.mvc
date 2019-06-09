using Elight.Entity;
using Elight.Entity.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elight.IService
{
    public partial interface IRoleService : IBaseService<Sys_Role, Guid>
    {
        /// <summary>
        /// 分页获取角色列表。
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="keyWord">角色编码或名称</param>
        /// <returns></returns>
        Page<Sys_Role> GetList(int pageIndex, int pageSize, string keyWord);
    }
}
