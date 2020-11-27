using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entity
{
    /// <summary>
    /// 角色
    /// </summary>
    public class Role
    {
        /// <summary>
        /// 角色編號
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// 角色類型
        /// </summary>
        [Required]
        public RoleType RoleType { get; set; }
    }

    public enum RoleType
    {
        System = 0,
        Admin = 1,
        Guest = 2
    }
}
