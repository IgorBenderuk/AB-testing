using AB_testing.Data.Dto.ResponceDto;
using AB_testing.Data.Models;

namespace AB_testing.Repos.Interfaces
{
    public interface IPurchaseProfitRepo : IGenericRepo<PurchaseProfit>
    {
        //interface for specific purchase implementation
        public int GetProfit();

        public Task<PurchaseProfitrStatistic> GetStatisticAsync();
    }
}
