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
    public class ButtonColorController : BaseController
    {
        public ButtonColorController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> AddButtonColorrecord( Guid? DeviceToken )
        {
            // creates device token, for testing purpuse, simulates scenario when client has real device_token 
            DeviceToken ??= Guid.NewGuid(); 
            if (!ModelState.IsValid) return BadRequest("Invalid modelstate");

            var existingButtoncolor = await unitOfWork.ButtonColorRepo.GetSingleAsync(DeviceToken.Value);

            if (existingButtoncolor != null)
            {
                return Ok(mapper.Map<ButtonColorResponceDTO>(existingButtoncolor));
            }

            ButtonColor buttonColor = new()
            {
                Id = DeviceToken.Value,
                X_Name = "Get ButtonColor Experiment",
                Button_Color = await unitOfWork.ButtonColorRepo.GetColor()
            };
            await unitOfWork.ButtonColorRepo.CreateAsync(buttonColor);
            await unitOfWork.CompleteAsync();

            return Ok(mapper.Map<ButtonColorResponceDTO>(buttonColor));
        }

        [HttpGet("Get_Statistic")]
        public  async Task<IActionResult> GetRecords()
        {
            //method returns distribution of each option and whole amount of records
            var records =await unitOfWork.ButtonColorRepo.GetStatisticAsync();

            return Ok(records);

        }
    }
}
