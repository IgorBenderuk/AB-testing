using AB_testing.Data;
using AB_testing.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AB_testing.Repos
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext,ILoggerFactory loggerFactory)
        {
            this.dbContext = dbContext;
            var logger = loggerFactory.CreateLogger("Logs");
            ButtonColorRepo = new ButtonColorRepo(dbContext, logger);
            PurchaseProfitRepo = new PurchaseProfitRepo(dbContext, logger);

        }

        public IButtonColorRepo ButtonColorRepo {  get;  }

        public IPurchaseProfitRepo PurchaseProfitRepo { get; }

        public async Task<bool> CompleteAsync()
        {
            var result = await dbContext.SaveChangesAsync();
            return result > 0;
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
