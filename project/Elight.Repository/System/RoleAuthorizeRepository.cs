using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elight.Entity;
using Elight.IRepository;

namespace Elight.Repository
{
    public partial class RoleAuthorizeRepository : BaseRepository<Sys_RoleAuthorize, Guid>, IRoleAuthorizeRepository
    {
        public List<Sys_RoleAuthorize> GetList(Guid roleId)
        {
            var condition = Repository
                .Where(t => t.RoleId == roleId);

            return condition.ToList();
        }

        public int DeleteByModuleIds(params Guid[] moduleIds)
        {
            return Delete(t => moduleIds.Contains(t.ModuleId.Value));
        }
    }
}
