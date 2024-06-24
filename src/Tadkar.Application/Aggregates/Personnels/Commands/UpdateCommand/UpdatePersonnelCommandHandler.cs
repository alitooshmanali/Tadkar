using MediatR;
using Tadkar.Application.Properties;
using Tadkar.Core.Exceptions;

namespace Tadkar.Application.Aggregates.Personnels.Commands.UpdateCommand
{
    public class UpdatePersonnelCommandHandler : IRequestHandler<UpdatePersonnelCommand>
    {
        private readonly IPersonnelRepository personnelRepository;

        public UpdatePersonnelCommandHandler(IPersonnelRepository personnelRepository)
        {
            this.personnelRepository = personnelRepository;
        }

        public async Task Handle(UpdatePersonnelCommand request, CancellationToken cancellationToken)
        {
            var personnel = await personnelRepository.GetByPersonelId(request.PersonnelId, cancellationToken).ConfigureAwait(false);

            if (personnel == null)
                throw new DomainException(ApplicationResources.Personnel_UnableToFind);

            personnel.ChangeFirsName(request.FirstName);
            personnel.ChangeLastName(request.LastName);
        }
    }
}
