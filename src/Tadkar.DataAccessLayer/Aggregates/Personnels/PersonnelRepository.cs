using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Tadkar.Application;
using Tadkar.Application.Aggregates.Personnels;
using Tadkar.Application.Aggregates.Personnels.Queries;
using Tadkar.Core.Aggregates.Personnels;
using Tadkar.DataAccessLayer.Context;

namespace Tadkar.DataAccessLayer.Aggregates.Personnels
{
    internal class PersonnelRepository : IPersonnelRepository
    {
        private readonly DatabaseContext dbContext;
        private readonly IMapper mapper;

        public PersonnelRepository(DatabaseContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void Add(Personnel personnel)
        {
            dbContext.Personnel.Add(personnel);
        }

        public void Delete(Personnel personnel)
        {
            personnel.Delete();
            dbContext.Personnel.Remove(personnel);
        }

        public async Task<BaseCollectionResult<PersonnelQueryResult>> GetAll()
        {
            var personnels = await dbContext.Personnel.AsNoTracking()
                .ProjectTo<PersonnelQueryResult>(mapper.ConfigurationProvider)
                .ToListAsync();

            return new BaseCollectionResult<PersonnelQueryResult>
            {
                Result = personnels.ToArray(),
                TotalCount = personnels.Count()
            };
        }

        public async Task<Personnel?> GetByPersonelId(int id, CancellationToken cancellationToken = default)
            => await dbContext.Personnel.SingleOrDefaultAsync(i=> i.Id == id, cancellationToken);
        
    }
}
