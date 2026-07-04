using RestWithASPNET10.Model;

namespace RestWithASPNET10.Repositories
{
    public interface IBookRepository
    {
        T Create(T book);
        T FindById(long id);
        List<T> FindAll();
        T Update(T book);
        void Delete(long id);
    }
}
