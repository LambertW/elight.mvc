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
    public partial class ItemRepository : BaseRepository<Sys_Item, Guid>, IItemRepository
    {
        public override List<Sys_Item> GetList()
        {
            return Repository.Where(t => t.DeleteMark == false).OrderBy(t => t.SortCode).ToList();
        }

        public Page<Sys_Item> GetList(int pageIndex, int pageSize, string keyWord)
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
