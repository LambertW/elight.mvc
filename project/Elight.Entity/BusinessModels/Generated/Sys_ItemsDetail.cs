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

	[JsonObject(MemberSerialization.OptIn), Table(Name = "dbo.Sys_ItemsDetail")]
    public partial class Sys_ItemsDetail : IEntity<string>
    {

		/// <summary>
		/// 主键
		/// </summary>
		[JsonProperty, Column(DbType = "varchar(50)")]
		public string Id { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
		[JsonProperty]
		public DateTime? CreateTime { get; set; }

		/// <summary>
		/// 创建人
		/// </summary>
		[JsonProperty, Column(DbType = "varchar(50)")]
		public string CreateUser { get; set; }

		/// <summary>
		/// 删除标记
		/// </summary>
		[JsonProperty]
		public bool? DeleteMark { get; set; }

		/// <summary>
		/// 编码
		/// </summary>
		[JsonProperty, Column(DbType = "varchar(50)")]
		public string EnCode { get; set; }

		/// <summary>
		/// 是否默认
		/// </summary>
		[JsonProperty]
		public bool? IsDefault { get; set; }

		/// <summary>
		/// 是否启用
		/// </summary>
		[JsonProperty]
		public bool? IsEnabled { get; set; }

		/// <summary>
		/// 父级
		/// </summary>
		[JsonProperty, Column(DbType = "varchar(50)")]
		public string ItemId { get; set; }

		/// <summary>
		/// 修改时间
		/// </summary>
		[JsonProperty]
		public DateTime? ModifyTime { get; set; }

		/// <summary>
		/// 修改人
		/// </summary>
		[JsonProperty, Column(DbType = "varchar(50)")]
		public string ModifyUser { get; set; }

		/// <summary>
		/// 选项名称
		/// </summary>
		[JsonProperty, Column(DbType = "varchar(50)")]
		public string Name { get; set; }

		/// <summary>
		/// 排序码
		/// </summary>
		[JsonProperty]
		public int? SortCode { get; set; }


		#region 外键 => 导航属性，ManyToMany

		#endregion
	}

}
