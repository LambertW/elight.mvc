using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elight.Entity;
using Elight.IRepository;

namespace Elight.Repository
{
    public partial class UserLogOnRepository : BaseRepository<Sys_UserLogOn, string>, IUserLogOnRepository
    {
        public Sys_UserLogOn GetByAccount(string userId)
        {
            return Repository.Where(t => t.UserId == userId).First();
        }

        public int Delete(params string[] userIds)
        {
            return Delete(t => userIds.Contains(t.UserId));
        }
    }
}
