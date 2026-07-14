using RestWithASPNET10.Data.DTO;
using RestWithASPNET10.Model;

namespace RestWithASPNET10.Services
{
    public interface IBookServices
    {
        BookDTO Create(BookDTO book);
        BookDTO FindById(long id);
        List<BookDTO> FindAll();
        BookDTO Update(BookDTO book);
        void Delete(long id);
    }
}
