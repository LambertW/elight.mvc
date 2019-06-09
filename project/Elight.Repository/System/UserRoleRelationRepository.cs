using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elight.Entity;
using Elight.IRepository;

namespace Elight.Repository
{
    public partial class UserRoleRelationRepository : BaseRepository<Sys_UserRoleRelation, Guid>, IUserRoleRelationRepository
    {
        public List<Sys_UserRoleRelation> GetList(Guid userId)
        {
            return Repository.Where(t => t.UserId == userId).ToList();
        }

        public int DeleteByUserIds(params Guid[] userIds)
        {
            return Delete(t => userIds.Contains(t.UserId.Value));
        }
    }
}
