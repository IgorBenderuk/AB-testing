namespace AB_testing.Repos.Interfaces
{
    public interface IUnitOfWork
    {
        IButtonColorRepo ButtonColorRepo { get; }
        IPurchaseProfitRepo PurchaseProfitRepo { get; }

        Task<bool> CompleteAsync();
    }
}
