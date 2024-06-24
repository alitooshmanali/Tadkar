using MediatR;
using Tadkar.Core.Aggregates.Personnels;

namespace Tadkar.Application.Aggregates.Personnels.Commands.CreateCommand
{
    public class CreatePersonnelCommandHandler : IRequestHandler<CreatePersonnelCommand>
    {
        private readonly IPersonnelRepository personnelRepository;

        public CreatePersonnelCommandHandler(IPersonnelRepository personnelRepository)
        {
            this.personnelRepository = personnelRepository;
        }

        public Task Handle(CreatePersonnelCommand request, CancellationToken cancellationToken)
        {
            var personnel = Personnel.Create(request.FirstName, request.LastName);

            personnelRepository.Add(personnel);

            return Task.CompletedTask;
        }
    }
}
