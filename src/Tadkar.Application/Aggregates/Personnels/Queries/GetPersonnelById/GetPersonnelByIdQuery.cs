using MediatR;
using System.ComponentModel.DataAnnotations;
using Tadkar.Core.Aggregates.Personnels;

namespace Tadkar.Application.Aggregates.Personnels.Queries.GetPersonnelById
{
    public class GetPersonnelByIdQuery: IRequest<Personnel>
    {
        [Required]
        public int PersonnelId { get; set; }
    }
}
