using RestWithASPNET10.Model;
using RestWithASPNET10.Model.Context;
using RestWithASPNET10.Repositories.Impl;

namespace RestWithASPNET10.Services.Implementations
{
    public class BookServices : IBookServices
    {
        private BookRepository _repository;
        public BookServices(MSSQLContext context)
        {
            _repository = new BookRepository(context);
        }
        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }
        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }
        public Book Create(Book book)
        {
            return _repository.Create(book);
        }
        public Book Update(Book book)
        {
            return _repository.Update(book);
        }
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
