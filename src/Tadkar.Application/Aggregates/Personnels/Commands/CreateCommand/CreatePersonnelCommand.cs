using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Tadkar.Application.Aggregates.Personnels.Commands.CreateCommand
{
    public class CreatePersonnelCommand: IRequest
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
    }
}
