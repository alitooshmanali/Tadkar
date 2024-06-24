
using Tadkar.Application;
using Tadkar.DataAccessLayer.Context;

namespace Tadkar.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext dbContext;

        public UnitOfWork(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public Task BeginTransaction(CancellationToken cancellationToken = default)
        {
            return dbContext.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransaction(CancellationToken cancellationToken = default)
        {
            await dbContext.Database.CommitTransactionAsync(cancellationToken).ConfigureAwait(false);
            await dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public Task RollbackTransaction(CancellationToken cancellationToken = default)
        {
            return dbContext.Database.RollbackTransactionAsync(cancellationToken);
        }
    }
}
