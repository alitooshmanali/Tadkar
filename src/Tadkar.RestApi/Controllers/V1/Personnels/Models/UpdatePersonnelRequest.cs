using System.ComponentModel.DataAnnotations;

namespace Tadkar.RestApi.Controllers.V1.Personnels.Models
{
    public class UpdatePersonnelRequest
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
    }
}
