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
    public partial class ItemsDetailRepository : BaseRepository<Sys_ItemsDetail, string>, IItemsDetailRepository
    {
        public Page<Sys_ItemsDetail> GetList(int pageIndex, int pageSize, string itemId, string keyWord)
        {
            var condition = Repository
                .Where(t => t.DeleteMark == false)
                .Where(t => t.ItemId == itemId)
                .WhereIf(!string.IsNullOrEmpty(keyWord), t => t.Name.Contains(keyWord) || t.EnCode.Contains(keyWord));

            return ToPage(condition, pageIndex, pageSize, "SortCode");
        }

        public int Delete(string itemId)
        {
            return Delete(t => t.ItemId == itemId);
        }
    }
}
