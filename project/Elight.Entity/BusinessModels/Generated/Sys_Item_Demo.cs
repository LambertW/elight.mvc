//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//     Website: http://www.freesql.net
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Elight.Entity {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "dbo.Sys_Item_Demo")]
    public partial class Sys_Item_Demo : IEntity<Guid>
    {

		[JsonProperty]
		public Guid Id { get; set; }

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string CreateUser { get; set; }

		[JsonProperty]
		public DateTime CreationTime { get; set; }

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string EnCode { get; set; }

		[JsonProperty]
		public bool IsActive { get; set; }

		[JsonProperty]
		public bool IsDeleted { get; set; }

		[JsonProperty]
		public bool? IsTree { get; set; }

		[JsonProperty]
		public DateTime? LastModificationTime { get; set; }

		[JsonProperty]
		public int? Layer { get; set; }

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string ModifyUser { get; set; }

		[JsonProperty, Column(DbType = "nvarchar(50)")]
		public string Name { get; set; }

		[JsonProperty]
		public Guid? ParentId { get; set; }

		[JsonProperty, Column(DbType = "nvarchar(500)")]
		public string Remark { get; set; }

		[JsonProperty]
		public int? SortCode { get; set; }


		#region 外键 => 导航属性，ManyToMany

		#endregion
	}

}
