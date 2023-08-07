using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using static Domain.Constants.Constants;
using static System.Net.Mime.MediaTypeNames;

namespace Domain.Models
{
    [Table("UserApplications")]
    public class UserApplication : ExtendedBaseModel
    {
        [Column(TypeName = "int")]
        public int UserID { get; set; }
        [Column(TypeName = "int")]
        public int PetID { get; set; }
        [Column(TypeName = "int")]
        public ApplicationTypes ApplicationType { get; set; }

        [Column(TypeName = "int")]
        public ApplicationStatuses ApplicationStatus { get; set; }
        public virtual Pet Pet { get; set; }
        public virtual User User { get; set; }
    }
}
