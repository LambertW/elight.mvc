using FreeSql.DataAnnotations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elight.Entity
{
    public partial class Sys_User
    {
        /// <summary>
        /// 保存角色部门名称。
        /// </summary>
        [Column(IsIgnore = true), JsonProperty]
        public string DeptName { get; set; }

        /// <summary>
        /// 保存用户角色ID。
        /// </summary>
        [Column(IsIgnore = true), JsonProperty]
        public List<string> RoleId { get; set; }
    }
}
