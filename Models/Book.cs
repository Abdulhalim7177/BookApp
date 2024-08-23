using Microsoft.Data.SqlClient;
using System.Data;

namespace BookApp.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string AuthorName { get; set; }
        public string PublisherName { get; set; }
        public string CategoryName { get; set; }

        public List<Book> GetBooks(string connectionString) {
            List<Book> bookList = new List<Book>();
            SqlConnection con = new SqlConnection(connectionString);
            string selectSql = "select BookId, Title, Isbn, AuthorName, PublisherName, CategoryName From GetBookData";
            con.Open();
            SqlCommand cmd = new SqlCommand(selectSql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    Book book = new Book();
                    book.BookId = Convert.ToInt32(dr["BookId"]);
                    book.Isbn = dr["Isbn"].ToString();
                    book.Title = dr["Title"].ToString();
                    book.AuthorName = dr["AuthorName"].ToString();
                    book.PublisherName = dr["PublisherName"].ToString();
                    book.CategoryName = dr["CategoryName"].ToString();

                    bookList.Add(book);
                }
            }
            return bookList;
        }
        public void CreateBook(string connectionString, Book book) {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("CreateBook", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Title", book.Title));
                    cmd.Parameters.Add(new SqlParameter("@Isbn", book.Isbn));
                    cmd.Parameters.Add(new SqlParameter("@AuthorName", book.AuthorName));
                    cmd.Parameters.Add(new SqlParameter("@PublisherName", book.PublisherName));
                    cmd.Parameters.Add(new SqlParameter("@CategoryName", book.CategoryName));

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Book GetBookData(string connectionString, int BookId) 
        { 
            SqlConnection con = new SqlConnection(connectionString);
            string selectSql = "select BookId, Title, AuthorName, Isbn, PublisherName, CategoryName from GetBookData where BookId =" + BookId;
            con.Open();
            SqlCommand cmd = new SqlCommand(selectSql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            Book book = new Book();
            if (dr != null) {
                while (dr.Read())
                {
                    book.BookId = Convert.ToInt32(dr["BookId"]);
                    book.Isbn = dr["Isbn"].ToString();
                    book.Title = dr["Title"].ToString();
                    book.AuthorName = dr["AuthorName"].ToString();
                    book.PublisherName = dr["PublisherName"].ToString();
                    book.CategoryName = dr["CategoryName"].ToString();
                }
                }
            return book;
        }
        public void EditBook(string connectionString, Book book)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UpdateBook", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@BookId", book.BookId));
                    cmd.Parameters.Add(new SqlParameter("@Title", book.Title));
                    cmd.Parameters.Add(new SqlParameter("@Isbn", book.Isbn));
                    cmd.Parameters.Add(new SqlParameter("@AuthorName", book.AuthorName));
                    cmd.Parameters.Add(new SqlParameter("@PublisherName", book.PublisherName));
                    cmd.Parameters.Add(new SqlParameter("@CategoryName", book.CategoryName));

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public void DeleteBooks(string connectionString, int BookId) 
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DeleteBook", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("BookId", BookId));

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch(Exception ex) { throw ex; }

        }

    }
}
