using BookApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookApp.Pages
{
    public class NewBookModel : PageModel
    {
        readonly IConfiguration _configuration;
        
        public string connectionString;

        public NewBookModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnPost()
        {
            Book book = new Book();

            book.Title = Request.Form["BookTitle"];
            book.Isbn = Request.Form["ISBN"];
            book.PublisherName = Request.Form["BookPublisher"];
            book.AuthorName = Request.Form["BookAuthor"];
            book.CategoryName = Request.Form["Category"];

            connectionString = _configuration.GetConnectionString("ConnectionString");
            book.CreateBook(connectionString, book);
            Response.Redirect("./Books");
        }
       
    }
}
