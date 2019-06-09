using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elight.Entity;
using Elight.Infrastructure;
using Elight.IService;
using Elight.IRepository;
using Elight.Entity.ResponseModels;

namespace Elight.Service
{
    public partial class ItemService : BaseService<Sys_Item, Guid>, IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IItemsDetailRepository _itemsDetailRepository;

        public ItemService(IItemRepository itemRepository, IItemsDetailRepository itemsDetailRepository) : base(itemRepository)
        {
            _itemRepository = itemRepository;
            _itemsDetailRepository = itemsDetailRepository;
        }

        public Page<Sys_Item> GetList(int pageIndex, int pageSize, string keyWord)
        {
            return _itemRepository.GetList(pageIndex, pageSize, keyWord);
        }

        public long GetChildCount(Guid parentId)
        {
            return _itemRepository.GetChildCount(parentId);
        }

        public override object Insert(Sys_Item model)
        {
            //model.Id = Guid.NewGuid().ToString();
            model.Layer = !model.ParentId.HasValue ? 1 : _itemRepository.Get(model.ParentId.Value).Layer += 1;
            model.IsEnabled = model.IsEnabled == null ? false : true;
            model.DeleteMark = false;
            model.CreateUser = OperatorProvider.Instance.Current.Account;
            model.CreateTime = DateTime.Now;
            model.ModifyUser = model.CreateUser;
            model.ModifyTime = model.CreateTime;
            return _itemRepository.Insert(model);
        }

        public override int Update(Sys_Item model)
        {
            model.Layer = !model.ParentId.HasValue ? 1 : _itemRepository.Get(model.ParentId.Value).Layer += 1;
            model.IsEnabled = model.IsEnabled == null ? false : true;
            model.ModifyUser = OperatorProvider.Instance.Current.Account;
            model.ModifyTime = DateTime.Now;
            var updateColumns = new List<string>() {
                "ParentId", "Layer", "EnCode", "Name", "SortCode", 
                "IsEnabled",  "Remark","ModifyUser", "ModifyTime" };
            return _itemRepository.Update(model, updateColumns);
        }

        public override int Delete(Guid[] primaryKeys)
        {
            _itemsDetailRepository.Delete(t => primaryKeys.Contains(t.ItemId.Value));
            return base.Delete(primaryKeys);
        }
    }
}
