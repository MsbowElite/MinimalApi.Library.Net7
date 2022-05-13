using System.Data;

namespace MinimalApi.Library.Net7.Data
{
    public interface IDbConnectionFactory
    {
        Task<IDbConnection> CreateConnectionAsync();
    }
}
