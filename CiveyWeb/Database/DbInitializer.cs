using System;
using System.Data;
using System.IO;
using Npgsql;

namespace CiveyWeb.Database
{
    public static class DbInitializer
    {
        private const string ConnectionStringTemplate =
            "Host=localhost;Port=5432;Username=postgres;Password=1234;Database={0}";
        public static void Initialize()
        {
            string defaultDatabaseName = "postgres";
            string civeyDatabaseName = "civey";
            using (var connection = new NpgsqlConnection(string.Format(ConnectionStringTemplate, defaultDatabaseName)))
            {
                connection.Open();
                var createDbCommand = connection.CreateCommand();
                createDbCommand.CommandType = CommandType.Text;
                createDbCommand.CommandText = $"create database {civeyDatabaseName};";
                createDbCommand.ExecuteNonQuery();
            }

            using var civeyConnection = new NpgsqlConnection(string.Format(ConnectionStringTemplate, civeyDatabaseName));
            civeyConnection.Open();
            var transaction = civeyConnection.BeginTransaction();
            try
            {
                var script = File.ReadAllText(Path.Combine("Database", "Scripts", "db_setup.sql"));
                var initDbCommand = civeyConnection.CreateCommand();
                initDbCommand.CommandType = CommandType.Text;
                initDbCommand.CommandText = script;
                initDbCommand.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                Console.WriteLine(e);
                throw;
            }
        }
    }
}