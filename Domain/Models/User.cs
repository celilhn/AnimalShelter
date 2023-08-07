using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Userssss")]
    public class User : ExtendedBaseModel
    {
        [Column(TypeName = "varchar(200)")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string UserName { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Password { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string SurName { get; set; }
        [Column(TypeName = "int")]
        public int RoleID { get; set; }
        public virtual Role Role { get; set; } 
    }
}
