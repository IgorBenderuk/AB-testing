using AB_testing.Data;
using AB_testing.Data.Dto.ResponceDto;
using AB_testing.Data.Models;
using AB_testing.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AB_testing.Repos
{
    public class ButtonColorRepo(AppDbContext dbContext, ILogger logger) : GenericRepo<ButtonColor>(dbContext, logger), IButtonColorRepo
    {
        //used in case of repository and unit of work pattern, injected in ID container in program.cs
        //repository with specific for ButtonColor functionality
        public override async Task<bool> UpDateAsync(ButtonColor entity)
        {
            try
            {
                var existingButtonColor =await GetSingleAsync(entity.Id);
                if (existingButtonColor == null) return false;

                existingButtonColor.Button_Color = entity.Button_Color;
                existingButtonColor.X_Name = entity.X_Name;

                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"AchivmentRepo UpDate,{typeof(ButtonColorRepo)}");
                throw;
            }

        }

        public override async Task<bool> RemoveAsync(Guid Id)
        {
            try
            {
                var existingButtonColor = await GetSingleAsync(Id);
                if (existingButtonColor == null)
                {
                    return false;
                }
                dbSet.Remove(existingButtonColor);

                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"AchivmentRepo Remove,{GetType().Name}");
                throw;
            }
        }

        private static readonly Random random = new();

        private static readonly List<Color> colors = new()
        {
            Color.Blue,
            Color.Green,
            Color.Red
        };

        public Task<Color> GetColor()
        {
            Color randomColor = colors[random.Next(0, colors.Count)];
            return Task.FromResult(randomColor);
        }
        
        public async Task<ButtonStatisticResponse> GetStatisticAsync()
        {
            ButtonStatisticResponse statistic = new ButtonStatisticResponse()
            {
                RecordsQuantity = dbSet.Count(),
                GreenOptionQuantity= await dbSet.CountAsync(b=>b.Button_Color==Color.Green),
                BlueOptionQuantity= await dbSet.CountAsync(b => b.Button_Color == Color.Blue),
                RedptionQuantity = await dbSet.CountAsync(b => b.Button_Color == Color.Red)
            };
            return  statistic;
        }
    }
}
