using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elight.Entity;
using Elight.IRepository;

namespace Elight.Repository
{
    public partial class RoleAuthorizeRepository : BaseRepository<Sys_RoleAuthorize, string>, IRoleAuthorizeRepository
    {
        public List<Sys_RoleAuthorize> GetList(object roleId)
        {
            var condition = Repository
                .Where(t => t.RoleId == roleId.ToString());

            return condition.ToList();
        }

        public int Delete(params string[] moduleIds)
        {
            return Delete(t => moduleIds.Contains(t.ModuleId));
        }
    }
}
