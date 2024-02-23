namespace AB_testing.Data.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = new Guid();

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    }
}
