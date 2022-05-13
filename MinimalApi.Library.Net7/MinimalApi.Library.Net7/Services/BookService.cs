using MinimalApi.Library.Net7.Models;

namespace MinimalApi.Library.Net7.Services
{
    public class BookService : IBookService
    {
        public Task<bool> CreateAsync(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string isbn)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Book?> GetByIsbnAsync(string isbn)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> SearchByTitleAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
