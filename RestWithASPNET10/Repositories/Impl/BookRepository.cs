using RestWithASPNET10.Model;
using RestWithASPNET10.Model.Context;

namespace RestWithASPNET10.Repositories.Impl
{
    public class BookRepository : IBookRepository
    {
        private MSSQLContext _context;
        public BookRepository(MSSQLContext context)
        {
            _context = context;
        }
        public List<T> FindAll()
        {
            return _context.Books.ToList();
        }
        public T FindById(long id)
        {
            return _context.Books.Find(id);
        }
        public T Create(T book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }
        public T Update(T book)
        {
            var bookBD = _context.Books.Find(book.Id);
            if (bookBD == null)
            {
                return null;
            }
            _context.Entry(bookBD).CurrentValues.SetValues(book);
            _context.SaveChanges();
            return book;
        }

        public void Delete(long id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return;
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
