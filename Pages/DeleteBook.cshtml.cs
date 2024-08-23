using BookApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookApp.Pages
{
    public class DeleteBookModel : PageModel
    {
        readonly IConfiguration _configuration;

        public string connectionString;

        public int BookId;

        public DeleteBookModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {
            BookId = Convert.ToInt16(Request.Query["BookId"]);
            connectionString = _configuration.GetConnectionString("ConnectionString");
            Book book = new Book();
            book.DeleteBooks(connectionString, BookId);
            Response.Redirect("./Books");
        }
    }
}
