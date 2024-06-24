using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Tadkar.Application.Aggregates.Personnels.Commands.UpdateCommand
{
    public class UpdatePersonnelCommand : IRequest
    {
        [Required]
        public int PersonnelId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
    }
}
