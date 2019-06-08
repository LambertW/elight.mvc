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

	[JsonObject(MemberSerialization.OptIn), Table(Name = "dbo.Sys_Organize")]
    public partial class Sys_Organize : IEntity<string>
    {

		/// <summary>
		/// 主键
		/// </summary>
		[JsonProperty, Column(DbType = "varchar(50)")]
		public string Id { get; set; }

		/// <summary>
		/// 地址
		/// </summary>
		[JsonProperty, Column(DbType = "varchar(50)")]
		public string Address { get; set; }

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
		/// 邮箱
		/// </summary>
		[JsonProperty, Column(DbType = "varchar(50)")]
		public string Email { get; set; }

		/// <summary>
		/// 编码
		/// </summary>
		[JsonProperty, Column(DbType = "varchar(50)")]
		public string EnCode { get; set; }

		/// <summary>
		/// 传真
		/// </summary>
		[JsonProperty, Column(DbType = "varchar(50)")]
		public string Fax { get; set; }

		/// <summary>
		/// 全称
		/// </summary>
		[JsonProperty, Column(DbType = "varchar(50)")]
		public string FullName { get; set; }

		/// <summary>
		/// 是否启用
		/// </summary>
		[JsonProperty]
		public bool? IsEnabled { get; set; }

		/// <summary>
		/// 层次
		/// </summary>
		[JsonProperty]
		public int? Layer { get; set; }

		/// <summary>
		/// 负责人
		/// </summary>
		[JsonProperty, Column(DbType = "varchar(50)")]
		public string ManagerId { get; set; }

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
		/// 父级
		/// </summary>
		[JsonProperty, Column(DbType = "varchar(50)")]
		public string ParentId { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		[JsonProperty, Column(DbType = "varchar(500)")]
		public string Remark { get; set; }

		/// <summary>
		/// 排序码
		/// </summary>
		[JsonProperty]
		public int? SortCode { get; set; }

		/// <summary>
		/// 固话
		/// </summary>
		[JsonProperty, Column(DbType = "varchar(50)")]
		public string TelePhone { get; set; }

		/// <summary>
		/// 分类
		/// </summary>
		[JsonProperty]
		public short? Type { get; set; }

		/// <summary>
		/// 微信
		/// </summary>
		[JsonProperty, Column(DbType = "varchar(50)")]
		public string WeChat { get; set; }


		#region 外键 => 导航属性，ManyToMany

		#endregion
	}

}
