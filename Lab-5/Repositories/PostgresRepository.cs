using System.Text;
using Bankomat.Services;
using Npgsql;

namespace Bankomat.Repositories;

public class PostgresRepository : IDataService
{
    public PostgresRepository()
    {
        string connectionString = "Host=localhost;Username=postgres;Password=postgres;Database=pgs";
        DataSource = NpgsqlDataSource.Create(connectionString);
    }

    private NpgsqlDataSource DataSource { get; set; }
    public int CreateAccount(string name, string pin)
    {
        string sql = "INSERT INTO accounts (account_name, account_pin, balance) VALUES (@name,@pin, 0)";
        NpgsqlCommand command = DataSource.CreateCommand(sql);
        command.Parameters.AddWithValue("name", name);
        command.Parameters.AddWithValue("pin", int.Parse(pin, null));
        command.ExecuteNonQuery();
        return 0;
    }

    public int Withdrawing(string name, int amount)
    {
        string sql = "UPDATE accounts SET balance = @amount where account_name = @name";
        NpgsqlCommand command = DataSource.CreateCommand(sql);
        command.Parameters.AddWithValue("name", name);
        command.Parameters.AddWithValue("amount", amount);
        command.ExecuteNonQuery();
        return 0;
    }

    public int Refill(string name, int amount)
    {
        string sql = "UPDATE accounts SET balance = @amount where account_name = @name";
        NpgsqlCommand command = DataSource.CreateCommand(sql);
        command.Parameters.AddWithValue("name", name);
        command.Parameters.AddWithValue("amount", amount);
        command.ExecuteNonQuery();
        return 0;
    }

    public int GetBalance(string name)
    {
        string sql = """
                     Select *
                     from accounts
                     where account_name = @name
                     """;
        NpgsqlCommand command = DataSource.CreateCommand(sql);
        command.Parameters.AddWithValue("name", name);
        NpgsqlDataReader reader = command.ExecuteReader();
        int balance = -1;
        while (reader.Read())
        {
            balance = (int)reader.GetDecimal(3);
        }

        return balance;
    }

    public string GetPin(string name)
    {
        string sql = "Select account_pin from accounts where account_name = @name";
        NpgsqlCommand command = DataSource.CreateCommand(sql);
        command.Parameters.AddWithValue("name", name);
        NpgsqlDataReader reader = command.ExecuteReader();
        reader.Read();
        return reader.GetInt32(0) + string.Empty;
    }

    public void RecordAction(string name, int oldBalance, int newBalance, string comment)
    {
        string sql0 = """
                      Select account_id
                      from accounts
                      where account_name = @name
                      """;
        NpgsqlCommand command0 = DataSource.CreateCommand(sql0);
        command0.Parameters.AddWithValue("name", name);
        NpgsqlDataReader reader = command0.ExecuteReader();
        reader.Read();
        int id = reader.GetInt32(0);

        string sql = "INSERT INTO operations_history (account_id, old_balance, new_balance, operation_comment) VALUES (@id, @old_balance, @new_balance, @operation_comment)";
        NpgsqlCommand command = DataSource.CreateCommand(sql);
        command.Parameters.AddWithValue("id", id);
        command.Parameters.AddWithValue("old_balance", oldBalance);
        command.Parameters.AddWithValue("new_balance", newBalance);
        command.Parameters.AddWithValue("operation_comment", comment);
        command.ExecuteNonQuery();
    }

    public string ShowHistory(string name)
    {
        string sql = "Select account_id from accounts where account_name = @name";

        NpgsqlCommand command = DataSource.CreateCommand(sql);
        command.Parameters.AddWithValue("name", name);
        NpgsqlDataReader reader = command.ExecuteReader();
        reader.Read();
        int id = reader.GetInt32(0);

        string sql1 = "Select * from operations_history where account_id = @id";
        NpgsqlCommand command1 = DataSource.CreateCommand(sql1);
        command1.Parameters.AddWithValue("id", id);
        NpgsqlDataReader reader1 = command1.ExecuteReader();
        var sb = new StringBuilder();
        while (reader1.Read())
        {
            sb.Append(reader1.GetInt32(0) + " ")
                .Append(reader1.GetDecimal(1) + " ")
                .Append("-> ")
                .Append(reader1.GetDecimal(2) + " ")
                .Append(reader1.GetString(3))
                .Append('\n');
        }

        return sb.ToString();
    }

    public string[] FindUser(string name)
    {
        string[] result = new string[4];

        string sql = "Select * from accounts where account_name = @name";
        NpgsqlCommand command = DataSource.CreateCommand(sql);
        command.Parameters.AddWithValue("name", name);
        NpgsqlDataReader reader = command.ExecuteReader();

        // if (reader.Read()) return Array.Empty<string>();
        while (reader.Read())
        {
            result[0] = reader.GetInt32(0) + string.Empty;
            result[1] = reader.GetString(1);
            result[2] = reader.GetInt32(2) + string.Empty;
            result[3] = reader.GetDecimal(3) + string.Empty;
        }

        reader.Close();

        return result;
    }
}