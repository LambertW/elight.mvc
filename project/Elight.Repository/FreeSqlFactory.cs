using Elight.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elight.Repository
{
    public static class FreeSqlFactory
    {
        public static IFreeSql Instance;

        static FreeSqlFactory()
        {
            Instance = new FreeSql.FreeSqlBuilder()
                .UseConnectionString(FreeSql.DataType.SqlServer, Configs.GetConnectionString("connStr"))
                .UseAutoSyncStructure(false)
                .Build();
        }
    }
}
