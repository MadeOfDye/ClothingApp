using ClothingStore.Persistence.Context;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Persistence.Tests.TestsContext
{
    public class ContextFactory: IDisposable
    {
        private readonly SqliteConnection _connection;
        public ApplicationDbContext Context { get; }

        public ContextFactory()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>().
                                UseSqlite(_connection).
                                EnableSensitiveDataLogging().
                                Options;
            Context = new ApplicationDbContext(options);

            Context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
            _connection.Close();
        }
    }
}
