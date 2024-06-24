using MediatR;

namespace Tadkar.Application.Aggregates.Personnels.Queries.GetPersonnelCollection
{
    public class GetPersonnelCollectionQueryHandler : IRequestHandler<GetPersonnelCollectionQuery, BaseCollectionResult<PersonnelQueryResult>>
    {
        private readonly IPersonnelRepository personnelRepository;

        public GetPersonnelCollectionQueryHandler(IPersonnelRepository personnelRepository)
        {
            this.personnelRepository = personnelRepository;
        }

        public async Task<BaseCollectionResult<PersonnelQueryResult>> Handle(GetPersonnelCollectionQuery request, CancellationToken cancellationToken)
        => await personnelRepository.GetAll().ConfigureAwait(false);
    }
}
