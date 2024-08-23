using BookApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace BookApp.Pages
{
    public class BooksModel : PageModel
    {
        readonly IConfiguration _configuration;
        public List<Book> books = new List<Book>();
        public string connectionString;

        public BooksModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {
            books = GetBookList();
        }

        private List<Book> GetBookList() 
        {
            connectionString = _configuration.GetConnectionString("ConnectionString");
            List<Book> bookList = new List<Book>();
            Book book = new Book();

            bookList = book.GetBooks(connectionString);
            
            return bookList;
        }


    }
}
