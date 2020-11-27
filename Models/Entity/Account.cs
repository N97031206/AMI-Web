using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entity
{
    public class Account
    {
        /// <summary>
        /// 帳戶編號
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// 帳號
        /// </summary>
        [Required]
        public string EmployeeID { get; set; }

        /// <summary>
        /// 帳號
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 電話
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 電子信箱
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// 建立日期
        /// </summary>
        [Required]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 更新日期
        /// </summary>
        [Required]
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// 是否啟用
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// 是否核准
        /// </summary>
        [Required]
        public bool IsApproved { get; set; }

        /// <summary>
        /// 是否封鎖
        /// </summary>
        [Required]
        public bool IsLocked { get; set; }

        /// <summary>
        /// 最後登入日期
        /// </summary>
        public DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// 角色編號
        /// </summary>
        [Required]
        public Guid RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
