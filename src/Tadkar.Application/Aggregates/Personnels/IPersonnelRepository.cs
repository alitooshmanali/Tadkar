using Tadkar.Application.Aggregates.Personnels.Queries;
using Tadkar.Core.Aggregates.Personnels;

namespace Tadkar.Application.Aggregates.Personnels
{
    public interface IPersonnelRepository
    {
        public void Add(Personnel personnel);

        public Task<Personnel?> GetByPersonelId(int id, CancellationToken cancellationToken = default);

        public Task<BaseCollectionResult<PersonnelQueryResult>> GetAll();

        public void Delete(Personnel personnel);
    }
}
