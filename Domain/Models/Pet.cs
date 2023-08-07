using Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Pets")]
    public class Pet : ExtendedBaseModel
    {
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string Text { get; set; }
        [Column(TypeName = "varchar(1000)")]
        public string Description { get; set; }
        [Column(TypeName = "int")]
        public int Age { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Color { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string ImageUrl { get; set; }
        [Column(TypeName = "int")]
        public int PetTypeID { get; set; }
        [Column(TypeName = "int")]
        public int OwnerID { get; set; }

        [Column(TypeName = "tinyint"), DefaultValue(0)]
        public short Approved { get; set; }
        public virtual PetType PetType { get; set; }
    }
}
