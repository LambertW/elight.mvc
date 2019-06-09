using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elight.IRepository;
using Elight.Entity;
using Elight.Entity.ResponseModels;

namespace Elight.Repository
{
    public partial class LogRepository : BaseRepository<Sys_Log, Guid>, ILogRepository
    {
        public Page<Sys_Log> GetList(int pageIndex, int pageSize, DateTime limitDate, string keyWord)
        {
            var condition = Repository
                .Where(t => t.CreateTime > limitDate)
                .Where(t => t.Account.Contains(keyWord) || t.RealName.Contains(keyWord));

            return ToPage(condition, pageIndex, pageSize, "CreateTime");
        }

        public int Delete(DateTime keepDate)
        {
            return Delete(t => t.CreateTime <= keepDate);
        }
    }
}
