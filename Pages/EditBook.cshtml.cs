using BookApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookApp.Pages
{
    public class EditBookModel : PageModel
    {
        readonly IConfiguration _configuration;

        public string connectionString;
        public Book BookDb = new Book();
        public int BookId;

        public EditBookModel (IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {
            BookId = Convert.ToInt32(Request.Query["BookId"]);
            Book book = new Book();
            connectionString = _configuration.GetConnectionString("ConnectionString");
            BookDb = book.GetBookData(connectionString, BookId);
        }
        public void OnPost() 
        {
            Book book = new Book();
            book.BookId = Convert.ToInt32(Request.Form["BookId"]);
            book.Title = Request.Form["BookTitle"];
            book.Isbn = Request.Form["BookIsbn"];
            book.AuthorName = Request.Form["BookAuthor"];
            book.PublisherName = Request.Form["BookPublisher"];
            book.CategoryName = Request.Form["BookCategory"];

            connectionString = _configuration.GetConnectionString("ConnectionString");

            book.EditBook(connectionString, book);
            Response.Redirect("./Books");
        }
    }
}
