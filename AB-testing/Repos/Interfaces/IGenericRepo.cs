namespace AB_testing.Repos.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        //interface for interacting with general repo implementation 
        Task<IEnumerable<T>?> GetAllAsync();

        Task<T?> GetSingleAsync(Guid Id);

        Task<bool> CreateAsync(T entity);

        Task<bool> UpDateAsync(T entity);

        Task<bool> RemoveAsync(Guid Id);


    }
}
