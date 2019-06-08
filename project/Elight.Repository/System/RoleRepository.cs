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
    public partial class RoleRepository : BaseRepository<Sys_Role, string>, IRoleRepository
    {
        public Page<Sys_Role> GetList(int pageIndex, int pageSize, string keyWord)
        {
            var condition = FreeSql.Select<Sys_Role>()
                .Where(t => t.DeleteMark == false)
                .WhereIf(!string.IsNullOrEmpty(keyWord), t => t.Name.Contains(keyWord) || t.EnCode.Contains(keyWord))
                .From<Sys_Organize>((r, o) => r.LeftJoin(a => a.OrganizeId == o.Id))
                .LeftJoin<Sys_Organize>((r, o) => r.OrganizeId == o.Id);
            var total = condition.Count();
            var items = condition.OrderBy((a, b) => a.SortCode)
                .ToList((a, b) => new Sys_Role
                {
                    AllowEdit = a.AllowEdit,
                    CreateTime = a.CreateTime,
                    CreateUser = a.CreateUser,
                    DeleteMark = a.DeleteMark,
                    EnCode = a.EnCode,
                    Id = a.Id,
                    IsEnabled = a.IsEnabled,
                    ModifyTime = a.ModifyTime,
                    ModifyUser = a.ModifyUser,
                    Name = a.Name,
                    OrganizeId = a.OrganizeId,
                    Remark = a.Remark,
                    SortCode = a.SortCode,
                    Type = a.Type,
                    DeptName = b.FullName
                });

            return new Page<Sys_Role> { Items = items, TotalItems = total };
        }

        public int Delete(params string[] primaryKeys)
        {
            return Delete(t => primaryKeys.Contains(t.Id));
        }

        public override List<Sys_Role> GetList()
        {
            return Repository.Where(t => t.DeleteMark == false).OrderBy(t => t.SortCode).ToList();
        }
    }
}
