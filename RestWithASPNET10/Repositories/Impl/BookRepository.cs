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
        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }
        public Book FindById(long id)
        {
            return _context.Books.Find(id);
        }
        public Book Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }
        public Book Update(Book book)
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
