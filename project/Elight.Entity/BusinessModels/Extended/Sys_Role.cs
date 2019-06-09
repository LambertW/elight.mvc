using FreeSql.DataAnnotations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elight.Entity
{
    public partial class Sys_Role
    {
        /// <summary>
        /// 保存角色部门名称。
        /// </summary>
        [Column(IsIgnore = true), JsonProperty]
        public string DeptName { get; set; }
    }
}
