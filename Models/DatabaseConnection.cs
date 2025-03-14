using Npgsql;

public class DatabaseConnection{

    private readonly string? _connectionString;

    public DatabaseConnection (IConfiguration configuration){

    

#pragma warning disable CS8601// possible null reference assignment

_connectionString = configuration.GetConnectionString("Defaultconnection");

#pragma warning restore CS8601//possible null reference assignment
    }


public NpgsqlConnection GetConnection (){
 var connection =new NpgsqlConnection(_connectionString);
 connection.Open();
 return connection;
}
}