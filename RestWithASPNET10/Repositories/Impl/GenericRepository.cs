using RestWithASPNET10.Model.Base;

namespace RestWithASPNET10.Repositories.Impl
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        public List<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public T FindById(long id)
        {
            throw new NotImplementedException();
        }

        public T Create(T item)
        {
            throw new NotImplementedException();
        }
        public T Update(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(long id)
        {
            throw new NotImplementedException();
        }
    }
}
