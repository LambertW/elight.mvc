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
    public partial class RoleService : BaseService<Sys_Role, Guid>, IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRoleAuthorizeRepository _roleAuthorizeRepository;

        public RoleService(IRoleRepository roleRepository, IRoleAuthorizeRepository roleAuthorizeRepository) : base(roleRepository)
        {
            _roleRepository = roleRepository;
            _roleAuthorizeRepository = roleAuthorizeRepository;
        }

        public Page<Sys_Role> GetList(int pageIndex, int pageSize, string keyWord)
        {
            return _roleRepository.GetList(pageIndex, pageSize, keyWord);
        }

        public override object Insert(Sys_Role model)
        {
            //model.Id = Guid.NewGuid().ToString();
            model.IsEnabled = model.IsEnabled == null ? false : true;
            model.AllowEdit = model.AllowEdit == null ? false : true;
            model.DeleteMark = false;
            model.CreateUser = OperatorProvider.Instance.Current.Account;
            model.CreateTime = DateTime.Now;
            model.ModifyUser = model.CreateUser;
            model.ModifyTime = model.CreateTime;
            return _roleRepository.Insert(model);
        }

        public override int Update(Sys_Role model)
        {
            model.IsEnabled = model.IsEnabled == null ? false : true;
            model.AllowEdit = model.AllowEdit == null ? false : true;
            model.ModifyUser = OperatorProvider.Instance.Current.Account;
            model.ModifyTime = DateTime.Now;
            var updateColumns = new List<string>() { 
                "OrganizeId", "EnCode", "Type", "Name", "AllowEdit",
                "IsEnabled", "Remark", "SortCode", "ModifyUser", "ModifyTime" };
            return _roleRepository.Update(model, updateColumns);
        }

        public override int Delete(Guid[] primaryKeys)
        {
            _roleAuthorizeRepository.Delete(t => primaryKeys.Contains(t.RoleId.Value));
            return base.Delete(primaryKeys);
        }
    }
}
