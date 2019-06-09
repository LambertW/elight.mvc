using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elight.Entity;
using Elight.Entity.ResponseModels;
using Elight.IRepository;

namespace Elight.Repository
{
    public partial class PermissionRepository : BaseRepository<Sys_Permission, Guid>, IPermissionRepository
    {
        public override List<Sys_Permission> GetList()
        {
            var condition = Repository
                .Where(t => t.DeleteMark == false)
                .OrderBy(t => t.SortCode);

            return condition.ToList();
        }

        public Page<Sys_Permission> GetList(int pageIndex, int pageSize, string keyWord)
        {
            var condition = Repository
                .Where(t => t.DeleteMark == false)
                .WhereIf(!string.IsNullOrEmpty(keyWord), t => t.Name.Contains(keyWord) || t.EnCode.Contains(keyWord));

            return ToPage(condition, pageIndex, pageSize, "SortCode");
        }

        public long GetChildCount(Guid parentId)
        {
            return Count(t => t.ParentId == parentId);
        }
    }
}
