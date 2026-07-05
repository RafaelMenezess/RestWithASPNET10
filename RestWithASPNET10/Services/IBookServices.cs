using RestWithASPNET10.Model;

namespace RestWithASPNET10.Services
{
    public interface IBookServices
    {
        Book Create(Book book);
        Book FindById(long id);
        List<Book> FindAll();
        Book Update(Book book);
        void Delete(long id);
    }
}
