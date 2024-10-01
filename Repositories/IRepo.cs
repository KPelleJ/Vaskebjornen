namespace Vaskebjørnen.Repositories
{
    public interface IRepo<T>
    {
        
        T GetBy(T t);
        List<T> GetAll();
        void Add(T t);
        void Update(T t);
        void Delete(T t);
    }
}
