using MinimalApi.Library.Net7.Filters;
using MinimalApi.Library.Net7.Models;

namespace MinimalApi.Library.Net7.Services
{
    public interface IBookService
    {
        public Task<bool> CreateAsync(Book book);

        public Task<Book?> GetByIsbnAsync(string isbn);

        public Task<IEnumerable<Book>> GetAllAsync();

        public Task<IEnumerable<Book>> SearchByTitleAsync(BookFilter filter);

        public Task<bool> UpdateAsync(Book book);

        public Task<bool> DeleteAsync(string isbn);
    }
}
