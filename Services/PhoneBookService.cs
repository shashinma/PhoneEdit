using System.Collections;
using PhoneEdit.Data;
using PhoneEdit.Models;

namespace PhoneEdit.Services;

public interface IBookService
{
    List<BookEntry> GetEntities();
}

public class BookService : IBookService
{
    private readonly PhonebookContext _context;

    public BookService(PhonebookContext context)
    {
        _context = context;
    }

    public List<BookEntry> GetEntities()
    {
        return _context.Entries.ToList();
    }
}