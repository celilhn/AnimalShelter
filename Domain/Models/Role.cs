using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Roles")]
    public class Role : ExtendedBaseModel
    {
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }
    }
}
