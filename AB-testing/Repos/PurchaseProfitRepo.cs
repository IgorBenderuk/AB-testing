using AB_testing.Data;
using AB_testing.Data.Dto.ResponceDto;
using AB_testing.Data.Models;
using AB_testing.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AB_testing.Repos
{
    public class PurchaseProfitRepo(AppDbContext dbContext, ILogger logger) : GenericRepo<PurchaseProfit>(dbContext, logger),IPurchaseProfitRepo
    {
        //repository with specific for Purchase functionality
        //used in case of repository and unit of work pattern, injected in ID container in program.cs
        private readonly Random random = new Random();
        
        public override async Task<bool> UpDateAsync(PurchaseProfit entity)
        {
            try
            {
                var existingPurchaseProfit = await GetSingleAsync(entity.Id);
                if (existingPurchaseProfit == null) return false;

                existingPurchaseProfit.Profit=entity.Profit;
                existingPurchaseProfit.X_Name=entity.X_Name;
                
                return true;
            }catch (Exception ex)
            {
                logger.LogError(ex, $"AchivmentRepo UpDate,{typeof(PurchaseProfitRepo)}");
                throw;
            }
        }

        public override async Task<bool> RemoveAsync(Guid Id)
        {
            try
            {
                var existingPurchaseProfit = await GetSingleAsync(Id);
                if (existingPurchaseProfit == null)
                {
                    return false;
                }
                dbSet.Remove(existingPurchaseProfit);

                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"AchivmentRepo Remove,{GetType().Name}");
                throw;
            }
        }

        public int GetProfit()
        {
            int randomNumber = random.Next(1, 101);
            // returns value bassed on given probability
            if (randomNumber <= 75)
            {
                return 10; // 75% chance for 10
            }
            else if (randomNumber <= 85)
            {
                return 20; // 10% chance for 20
            }
            else if (randomNumber <= 90)
            {
                return 50; // 5% chance for 50
            }
            else
            {
                return 5; // 10% chance for 5
            }
        }

        public async Task<PurchaseProfitrStatistic> GetStatisticAsync()
        {
            PurchaseProfitrStatistic purchaseProfitrStatistic = new PurchaseProfitrStatistic()
            {
                RecordsQuantity= await dbSet.CountAsync(),
                OptionProfit10 = await dbSet.CountAsync(p =>p.Profit==10), 
                OptionProfit20 = await dbSet.CountAsync(p => p.Profit == 20),
                OptionProfit50 = await dbSet.CountAsync(p => p.Profit == 50),
                OptionProfit5 = await dbSet.CountAsync(p => p.Profit == 5),
            };
            return purchaseProfitrStatistic;

        }
    }
} 
