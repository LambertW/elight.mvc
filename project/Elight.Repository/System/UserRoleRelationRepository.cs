using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elight.Entity;
using Elight.IRepository;

namespace Elight.Repository
{
    public partial class UserRoleRelationRepository : BaseRepository<Sys_UserRoleRelation, string>, IUserRoleRelationRepository
    {
        public List<Sys_UserRoleRelation> GetList(string userId)
        {
            return Repository.Where(t => t.UserId == userId).ToList();
        }

        public int Delete(params string[] userIds)
        {
            return Delete(t => userIds.Contains(t.UserId));
        }
    }
}
