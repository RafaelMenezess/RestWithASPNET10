using Mapster;
using RestWithASPNET10.Data.DTO;
using RestWithASPNET10.Model;
using RestWithASPNET10.Repositories;

namespace RestWithASPNET10.Services.Implementations
{
    public class BookServices : IBookServices
    {
        private IRepository<Book> _repository;
        public BookServices(IRepository<Book> repository)
        {
            _repository = repository;
        }
        public List<BookDTO> FindAll()
        {
            return _repository.FindAll().Select(item => item.Adapt<BookDTO>()).ToList();
        }
        public BookDTO FindById(long id)
        {
            return _repository.FindById(id).Adapt<BookDTO>();
        }
        public BookDTO Create(BookDTO book)
        {
            var bookEntity = book.Adapt<Book>();
            bookEntity = _repository.Create(bookEntity);
            return bookEntity.Adapt<BookDTO>();
        }
        public BookDTO Update(BookDTO book)
        {
            var bookEntity = book.Adapt<Book>();
            bookEntity = _repository.Update(bookEntity);
            return bookEntity.Adapt<BookDTO>();
        }
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
