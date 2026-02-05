namespace EngineeringManagement.Repositories
{
    public interface IRepository<T>
    {
        void Add(T obj);
        void Update(T obj);
        T GetById(int id);
        List<T> GetAll();
        void Delete(int id);
        void Save();
    }
}
