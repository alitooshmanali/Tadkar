using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Tadkar.Application.Aggregates.Personnels.Commands.DeleteCommand
{
    public class DeletePersonnelCommand: IRequest
    {
        [Required]
        public int PersonnelId { get; set; }    
    }
}
