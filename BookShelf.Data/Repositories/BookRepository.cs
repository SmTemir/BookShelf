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
        private string ConnectionString { get; } = ConfigurationManager.ConnectionStrings["BookShelfConnection"].ConnectionString;

        public List<Book> List(BookQuery query)
        {
            var conditions = "WHERE 1=1 ";
            if (query.Title != null) conditions += "AND Title = @Title ";
            if (query.Author != null) conditions += "AND Author = @Author ";
            if (query.IsAbsent != null) conditions += "AND IsAbsent = @IsAbsent ";

            var orderBy = "ORDER BY ID ";
            if (query.OrderBy != null) orderBy = "ORDER BY @OrderBy ";
            if (query.SortDirection != null) orderBy += "@SortDirection";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var books = connection.Query<Book>($@"SELECT * FROM Books {conditions} {orderBy} OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY", query).ToList();

                connection.Close();

                return books;
            }
        }

        public void Insert(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                connection.Execute("INSERT INTO Books VALUES (@Title, @Author, @Publisher, @PublishDate, @IsAbsent, @BeginDate, null)", book);

                connection.Close();
            }
        }
    }
}
