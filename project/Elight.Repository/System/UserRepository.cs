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
    public partial class UserRepository : BaseRepository<Sys_User, string>, IUserRepository
    {
        public Sys_User GetByAccount(string account)
        {
            return Repository.Where(t => t.Account == account).First();
        }

        public Page<Sys_User> GetList(int pageIndex, int pageSize, string keyWord)
        {
            var condition = FreeSql.Select<Sys_User>()
                .Where(t => t.DeleteMark == false)
                .WhereIf(!string.IsNullOrEmpty(keyWord), t => t.Account.Contains(keyWord) || t.RealName.Contains(keyWord))
                .From<Sys_Organize>((u, o) => u.LeftJoin(a => a.DepartmentId == o.Id));
            var total = condition.Count();
            var items = condition.OrderBy((a, b) => a.SortCode).ToList((a, b) =>
                new Sys_User
                {
                    Account = a.Account,
                    Address = a.Address,
                    Avatar = a.Avatar,
                    Birthday = a.Birthday,
                    CompanyId = a.CompanyId,
                    CreateTime = a.CreateTime,
                    CreateUser = a.CreateUser,
                    DeleteMark = a.DeleteMark,
                    DepartmentId = a.DepartmentId,
                    Email = a.Email,
                    Gender = a.Gender,
                    Id = a.Id,
                    IsEnabled = a.IsEnabled,
                    MobilePhone = a.MobilePhone,
                    ModifyTime = a.ModifyTime,
                    ModifyUser = a.ModifyUser,
                    NickName = a.NickName,
                    RealName = a.RealName,
                    //RoleId = a.RoleId,
                    Signature = a.Signature,
                    SortCode = a.SortCode,
                    DeptName = b.FullName
                }
            ); 

            return new Page<Sys_User> { Items = items, TotalItems = total };
        }

        public int Delete(string[] primaryKeys)
        {
            return Delete(t => primaryKeys.Contains(t.Id));
        }
    }
}
