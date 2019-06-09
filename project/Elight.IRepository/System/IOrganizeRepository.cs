using Elight.Entity;
using Elight.Entity.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elight.IRepository
{
    public partial interface IOrganizeRepository : IBaseRepository<Sys_Organize, Guid>
    {
        /// <summary>
        /// 分页获取组织机构列表。
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="keyWord">编码或名称</param>
        /// <returns></returns>
        Page<Sys_Organize> GetList(int pageIndex, int pageSize, string keyWord);

        /// <summary>
        /// 获取子级机构数量。
        /// </summary>
        /// <param name="parentId">父级机构ID</param>
        /// <returns></returns>
        long GetChildCount(Guid parentId);
    }
}
