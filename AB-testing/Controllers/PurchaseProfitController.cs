using AB_testing.Data.Dto.ResponceDto;
using AB_testing.Data.Models;
using AB_testing.Repos.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AB_testing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseProfitController : BaseController
    {
        public PurchaseProfitController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> AddButtonColorrecord(Guid? DeviceToken)
        {
            DeviceToken ??= Guid.NewGuid(); // creates device token, for testing purpuse, simulates scenario when client has real device_token 
            if (!ModelState.IsValid) return BadRequest("Invalid modelstate");

            PurchaseProfit? purchaseProfit = await unitOfWork.PurchaseProfitRepo.GetSingleAsync(DeviceToken.Value);

            if (purchaseProfit != null)
            {
                return Ok(mapper.Map<PurchaseProfitResponseDTO>(purchaseProfit));
            }

            purchaseProfit = new PurchaseProfit()
            {
                Id = DeviceToken.Value,
                Profit = unitOfWork.PurchaseProfitRepo.GetProfit(),
                X_Name = "Get Profit Experiment"
            };

            await unitOfWork.PurchaseProfitRepo.CreateAsync(purchaseProfit);
            await unitOfWork.CompleteAsync();

            return Ok(mapper.Map<PurchaseProfitResponseDTO>(purchaseProfit));
        }

        [HttpGet("Get_Statistic")]
        public async Task<IActionResult> GetRecords()
        {
             //method returns distribution of each option and whole amount of records
            var records = await unitOfWork.PurchaseProfitRepo.GetStatisticAsync();

            return Ok(records);



        }
    }
}
