using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elight.Infrastructure;
using Elight.Entity;
using Elight.IService;
using Elight.IRepository;
using Elight.Entity.ResponseModels;

namespace Elight.Service
{
    public partial class OrganizeService : BaseService<Sys_Organize, Guid>, IOrganizeService
    {
        private readonly IOrganizeRepository _organizeRepository;

        public OrganizeService(IOrganizeRepository organizeRepository) : base(organizeRepository)
        {
            _organizeRepository = organizeRepository;
        }

        public Page<Sys_Organize> GetList(int pageIndex, int pageSize, string keyWord)
        {
            return _organizeRepository.GetList(pageIndex, pageSize, keyWord);
        }

        public override object Insert(Sys_Organize model)
        {
            //model.Id = Guid.NewGuid().ToString();
            model.Layer = !model.ParentId.HasValue ? 0 : _organizeRepository.Get(model.ParentId.Value).Layer += 1;
            model.DeleteMark = false;
            model.CreateUser = OperatorProvider.Instance.Current.Account;
            model.CreateTime = DateTime.Now;
            model.ModifyUser = model.CreateUser;
            model.ModifyTime = model.CreateTime;
            return _organizeRepository.Insert(model);
        }

        public override int Update(Sys_Organize model)
        {
            model.ModifyUser = OperatorProvider.Instance.Current.Account;
            model.ModifyTime = DateTime.Now;
            var updateColumns = new List<string>() {
                "ParentId", "Layer", "EnCode", "FullName", "Type", 
                "ManagerId", "TelePhone", "WeChat", "Fax", "Email" , 
                "Address", "SortCode","IsEnabled","Remark", "ModifyUser" , "ModifyTime"};
            return _organizeRepository.Update(model, updateColumns);
        }

        public long GetChildCount(Guid parentId)
        {
            return _organizeRepository.GetChildCount(parentId);
        }
    }
}
