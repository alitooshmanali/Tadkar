using MediatR;
using Tadkar.Application.Properties;
using Tadkar.Core.Exceptions;

namespace Tadkar.Application.Aggregates.Personnels.Commands.DeleteCommand
{
    public class DeletePersonnelCommandHandler : IRequestHandler<DeletePersonnelCommand>
    {
        private readonly IPersonnelRepository personnelRepository;

        public DeletePersonnelCommandHandler(IPersonnelRepository personnelRepository)
        {
            this.personnelRepository = personnelRepository;
        }

        public async Task Handle(DeletePersonnelCommand request, CancellationToken cancellationToken)
        {
            var personnel = await personnelRepository.GetByPersonelId(request.PersonnelId, cancellationToken)
                .ConfigureAwait(false);

            if (personnel == null)
                throw new DomainException(ApplicationResources.Personnel_UnableToFind);

            personnelRepository.Delete(personnel);
        }
    }
}
