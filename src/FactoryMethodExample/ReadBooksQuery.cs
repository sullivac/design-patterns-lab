using System.Collections.Generic;
using System.Data;

namespace FactoryMethodExample
{
    public class ReadBooksQuery
    {
        private readonly IDbConnection connection;

        public ReadBooksQuery(IDbConnection connection)
        {
            this.connection = connection;
        }

        public IList<Book> GetAll()
        {
            using (IDbTransaction transaction = connection.BeginTransaction())
            using (IDbCommand command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandText = @"select * from Books";

                using (IDataReader reader = command.ExecuteReader())
                {
                    var ordinals = new Dictionary<string, int>
                    {
                        { "Id", reader.GetOrdinal("Id") },
                        { "Title", reader.GetOrdinal("Title") },
                        { "Author", reader.GetOrdinal("Author") }
                    };

                    var result = new List<Book>();

                    while (reader.Read())
                    {
                        result.Add(new Book
                        {
                            Id = reader.GetGuid(ordinals["Id"]),
                            Title = reader.GetString(ordinals["Title"]),
                            Author = reader.GetString(ordinals["Author"])
                        });
                    }

                    return result;
                }
            }
        }
    }
}
