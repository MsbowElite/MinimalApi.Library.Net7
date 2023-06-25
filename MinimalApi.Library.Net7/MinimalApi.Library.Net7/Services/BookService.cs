using Dapper;
using MinimalApi.Library.Net7.Data;
using MinimalApi.Library.Net7.Filters;
using MinimalApi.Library.Net7.Models;

namespace MinimalApi.Library.Net7.Services
{
    public class BookService : IBookService
    {
        private readonly IDbConnectionFactory dbConnectionFactory;

        public BookService(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<bool> CreateAsync(Book book)
        {
            var existingBook = await GetByIsbnAsync(book.Isbn);
            if (existingBook is not null)
            {
                return false;
            }

            using var connection = await dbConnectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(
                @"INSERT INTO Books (Isbn, Title, Author, ShortDescription, PageCount, ReleaseDate) 
                VALUES (@Isbn, @Title, @Author, @ShortDescription, @PageCount, @ReleaseDate)",
                book);
            return result > 0;
        }

        public async Task<Book?> GetByIsbnAsync(string isbn)
        {
            using var connection = await dbConnectionFactory.CreateConnectionAsync();
            return connection.QuerySingleOrDefault<Book>(
                "SELECT * FROM Books WHERE Isbn = @Isbn LIMIT 1", new { Isbn = isbn });
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            using var connection = await dbConnectionFactory.CreateConnectionAsync();
            return await connection.QueryAsync<Book>("SELECT * FROM Books");
        }

        public async Task<IEnumerable<Book>> SearchByTitleAsync(BookFilter filter)
        {
            using var connection = await dbConnectionFactory.CreateConnectionAsync();
            return await connection.QueryAsync<Book>(
                "SELECT * FROM Books WHERE Title LIKE '%' || @SearchTerm || '%'" +
                " LIMIT @Limit OFFSET @Offset",
                new { filter.SearchTerm, filter.Limit, filter.Offset });
        }

        public async Task<bool> UpdateAsync(Book book)
        {
            var existingBook = await GetByIsbnAsync(book.Isbn);
            if (existingBook is null)
            {
                return false;
            }

            using var connection = await dbConnectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(
                @"UPDATE Books SET Title = @Title, Author = @Author, ShortDescription = @ShortDescription,
                    PageCount = @PageCount, ReleaseDate = @ReleaseDate WHERE Isbn = @Isbn",
                book);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(string isbn)
        {
            using var connection = await dbConnectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(
                @"DELETE FROM Books WHERE Isbn = @Isbn", new { Isbn = isbn });
            return result > 0;
        }
    }
}
