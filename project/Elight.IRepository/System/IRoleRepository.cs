using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elight.Entity;
using Elight.Entity.ResponseModels;

namespace Elight.IRepository
{
    public partial interface IRoleRepository : IBaseRepository<Sys_Role, string>
    {
        /// <summary>
        /// 获取所有角色列表。
        /// </summary>
        /// <returns></returns>
        //List<Sys_Role> GetList();
        Page<Sys_Role> GetList(int pageIndex, int pageSize, string keyWord);
        int Delete(params string[] primaryKeys);
    }
}
