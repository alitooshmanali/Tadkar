using MediatR;
using Tadkar.Application.Properties;
using Tadkar.Core.Aggregates.Personnels;
using Tadkar.Core.Exceptions;

namespace Tadkar.Application.Aggregates.Personnels.Queries.GetPersonnelById
{
    public class GetPersonnelByIdQueryHandler : IRequestHandler<GetPersonnelByIdQuery, Personnel>
    {
        private readonly IPersonnelRepository personnelRepository;

        public GetPersonnelByIdQueryHandler(IPersonnelRepository personnelRepository)
        {
            this.personnelRepository = personnelRepository;
        }

        public async Task<Personnel> Handle(GetPersonnelByIdQuery request, CancellationToken cancellationToken) =>
            await personnelRepository.GetByPersonelId(request.PersonnelId, cancellationToken)
                .ConfigureAwait(false) ?? throw new DomainException(ApplicationResources.Personnel_UnableToFind);
    }
}
