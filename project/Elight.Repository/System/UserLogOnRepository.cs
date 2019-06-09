using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elight.Entity;
using Elight.IRepository;

namespace Elight.Repository
{
    public partial class UserLogOnRepository : BaseRepository<Sys_UserLogOn, Guid>, IUserLogOnRepository
    {
        public Sys_UserLogOn GetByAccount(Guid userId)
        {
            return Repository.Where(t => t.UserId == userId).First();
        }

        public int DeleteByUserIds(params Guid[] userIds)
        {
            return Delete(t => userIds.Contains(t.UserId.Value));
        }
    }
}
