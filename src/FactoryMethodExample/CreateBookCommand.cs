using System;
using System.Data;

namespace FactoryMethodExample
{
    public class CreateBookCommand
    {
        private readonly Book book;
        private readonly IDbConnection connection;

        public CreateBookCommand(Book book, IDbConnection connection)
        {
            if (book == null) { throw new ArgumentNullException("book", "book is null."); }
            if (connection == null) { throw new ArgumentNullException("connection", "connection is null."); }

            this.book = book;
            this.connection = connection;
        }

        public void Execute()
        {
            using (IDbTransaction transaction = connection.BeginTransaction())
            using (IDbCommand command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandText = @"insert into Books (
    Id,
    Title,
    Author
)
values
(
    @Id,
    @Title,
    @Author
)";

                IDbDataParameter idParameter = command.CreateParameter();
                idParameter.DbType = DbType.Guid;
                idParameter.ParameterName = "@Id";
                idParameter.Value = book.Id;
                command.Parameters.Add(idParameter);

                IDbDataParameter titleParameter = command.CreateParameter();
                titleParameter.DbType = DbType.String;
                titleParameter.ParameterName = "@Title";
                titleParameter.Value = book.Title;
                command.Parameters.Add(titleParameter);

                IDbDataParameter authorParameter = command.CreateParameter();
                authorParameter.DbType = DbType.String;
                authorParameter.ParameterName = "@Author";
                authorParameter.Value = book.Author;
                command.Parameters.Add(authorParameter);

                command.ExecuteNonQuery();

                transaction.Commit();
            }
        }
    }
}
