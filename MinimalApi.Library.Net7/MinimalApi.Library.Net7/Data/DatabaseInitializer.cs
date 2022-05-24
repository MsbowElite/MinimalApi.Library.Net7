using Dapper;

namespace MinimalApi.Library.Net7.Data
{
    public class DatabaseInitializer
    {
        private readonly IDbConnectionFactory dbConnectionFactory;

        public DatabaseInitializer(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task InitializeAsync()
        {
            using var connection = await dbConnectionFactory.CreateConnectionAsync();
            await connection.ExecuteAsync(
                @"CREATE TABLE IF NOT EXISTS Book (
                Isbn TEXT PRIMARY KEY,
                Title TEXT NOT NULL,
                Author TEXT NOT NULL,
                ShortDescription TEXT NOT NULL,
                PageCount INTEGER,
                ReleaseDate TEXT NOT NULL)"
                );
        }
    }
}
