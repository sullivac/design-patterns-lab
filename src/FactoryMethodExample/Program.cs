using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlLocalDb;

namespace FactoryMethodExample
{
    public class Program
    {
        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            var books = new List<Book>
            {
                new Book { Id = Guid.NewGuid(), Author = "Author 1", Title = "Book 1" },
                new Book { Id = Guid.NewGuid(), Author = "Author 2", Title = "Book 2" },
                new Book { Id = Guid.NewGuid(), Author = "Author 3", Title = "Book 3" }
            };

            Console.WriteLine("===============================================================================");
            Console.WriteLine("Using Sqlite");
            Console.WriteLine("===============================================================================");
            using (var connection = new SQLiteConnection(@"Data Source=:memory:;Version=3;New=True;"))
            {
                connection.Open();

                InitializeSqlite(connection);

                Execute(books, connection);

                connection.Close();
            }

            Console.WriteLine();
            Console.WriteLine("===============================================================================");
            Console.WriteLine("Using LocalDb (SQL Server)");
            Console.WriteLine("===============================================================================");
            using (TemporarySqlLocalDbInstance instance = TemporarySqlLocalDbInstance.Create(true))
            using (SqlConnection connection = instance.CreateConnection())
            {
                connection.Open();

                InitializeLocalDb(connection);

                Execute(books, connection);

                connection.Close();
            }
        }

        private static void Execute(List<Book> books, IDbConnection connection)
        {
            IEnumerable<CreateBookCommand> commands = books.Select(book => new CreateBookCommand(book, connection));
            foreach (CreateBookCommand command in commands)
            {
                command.Execute();
            }

            var query = new ReadBooksQuery(connection);

            IList<Book> all = query.GetAll();
            for (int index = 0; index < all.Count; index++)
            {
                if (index > 0) { Console.WriteLine(); }

                Console.WriteLine("Id:     {0}", all[index].Id);
                Console.WriteLine("Title:  {0}", all[index].Title);
                Console.WriteLine("Author: {0}", all[index].Author);
            }
        }

        private static void InitializeSqlite(SQLiteConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"create table Books (
        Id     text primary key not null,
        Title  text not null,
        Author text not null
    )";

                command.ExecuteNonQuery();
            }
        }

        private static void InitializeLocalDb(SqlConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"create table Books (
        Id     uniqueidentifier primary key not null,
        Title  nvarchar(50)     not null,
        Author nvarchar(50)     not null
    )";

                command.ExecuteNonQuery();
            }
        }
    }
}
