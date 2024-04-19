namespace HBApi.Persistance
{
    public interface IRepositoryBase<T>
    {
        Task<T> GetById(int id);

        Task<T> Update(T model);
    }
}