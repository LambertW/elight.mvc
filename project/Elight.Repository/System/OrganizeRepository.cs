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
    public partial class OrganizeRepository : BaseRepository<Sys_Organize, Guid>, IOrganizeRepository
    {
        public override List<Sys_Organize> GetList()
        {
            var condition = Repository
                .Where(t => t.DeleteMark == false)
                .OrderBy(t => t.SortCode);

            return condition.ToList();
        }

        public Page<Sys_Organize> GetList(int pageIndex, int pageSize, string keyWord)
        {
            var condition = Repository
                .Where(t => t.DeleteMark == false)
                .WhereIf(!string.IsNullOrEmpty(keyWord), t => t.FullName.Contains(keyWord) || t.EnCode.Contains(keyWord));

            return ToPage(condition, pageIndex, pageSize, "SortCode");
        }

        public long GetChildCount(Guid parentId)
        {
            return Count(t => t.ParentId == parentId);
        }
    }
}
