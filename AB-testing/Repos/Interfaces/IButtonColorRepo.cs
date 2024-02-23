using AB_testing.Data.Dto.ResponceDto;
using AB_testing.Data.Models;

namespace AB_testing.Repos.Interfaces
{
    public interface IButtonColorRepo : IGenericRepo<ButtonColor>
    {

        public Task<Color> GetColor();
        public Task<ButtonStatisticResponse> GetStatisticAsync();



    }
}
