using BookShelf.Data.Entities;
using BookShelf.Data.Queries;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace BookShelf.Data.Repositories
{
    public class BookRepository
    {
        private string connectionString { get; } = ConfigurationManager.ConnectionStrings["BookShelfConnection"].ConnectionString;

        public List<Book> List(BookQuery query)
        {
            var conditions = "WHERE 1=1 ";
            if (query.Title != null) conditions += "AND Title = @Title ";
            if (query.Author != null) conditions += "AND Author = @Author ";
            if (query.IsAbsent != null) conditions += "AND IsAbsent = @IsAbsent ";

            var orderBy = "ORDER BY ID ";
            if (query.OrderBy != null) orderBy = "ORDER BY @OrderBy ";
            if (query.SortDirection != null) orderBy += "@SortDirection";

            List<Book> books = null;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                books = connection.Query<Book>($@"SELECT * FROM Books {conditions} {orderBy} OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY", query).ToList();

                connection.Close();    
            }

            return books;
        }

        public Book Get(int id)
        {
            //if (id == null) throw new ArgumentNullException(nameof(id));

            Book book;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                book = connection.Query<Book>("SELECT * FROM Books WHERE ID = @id", new { id }).FirstOrDefault();

                connection.Close();
            }

            return book;
        }

        public void Insert(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                connection.Execute("INSERT INTO Books VALUES (@Title, @Author, @Publisher, @PublishDate, @IsAbsent, @BeginDate, null)", book);

                connection.Close();
            }
        }

        public void Update(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                connection.Execute("UPDATE Books SET Title = @Title, Author = @Author, Publisher = @Publisher, PublishDate = @PublishDate, IsAbsent = @IsAbsent, BeginDate = @BeginDate, DeleteDate = @DeleteDate WHERE ID = @ID", book);

                connection.Close();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                connection.Execute("Delete FROM Books WHERE ID = @ID", new { id });

                connection.Close();
            }
        }
    }
}
