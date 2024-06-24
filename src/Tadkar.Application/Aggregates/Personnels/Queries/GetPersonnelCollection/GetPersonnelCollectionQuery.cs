using MediatR;
using Tadkar.Core.Aggregates.Personnels;

namespace Tadkar.Application.Aggregates.Personnels.Queries.GetPersonnelCollection
{
    public class GetPersonnelCollectionQuery: IRequest<BaseCollectionResult<PersonnelQueryResult>>
    {
    }
}
