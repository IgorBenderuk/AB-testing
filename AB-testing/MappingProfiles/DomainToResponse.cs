using AB_testing.Data.Dto.ResponceDto;
using AB_testing.Data.Models;
using AutoMapper;

namespace AB_testing.MappingProfiles
{
    public class DomainToResponse:Profile
    {
        public DomainToResponse()
        {

            //returns coresponding HEX value based on stored one
            CreateMap<ButtonColor,ButtonColorResponceDTO>(
               ).ForMember(des=>des.Button_Color,opt=>opt.MapFrom(src=>GetHexColor(src.Button_Color)));

            CreateMap<PurchaseProfit, PurchaseProfitResponseDTO>(); 

        }

        private string GetHexColor(Color color)//method for returning coresponding values  
        {
            return color switch
            {
                Color.Red => "#FF0000",
                Color.Green => "#00FF00",
                Color.Blue => "#0000FF",
                _ => throw new ArgumentOutOfRangeException(nameof(color), "Unsupported color"),
            };
        }

    }
}
