using Fahrgemeinschaft.Models;
using Dapper;
using MySqlConnector;

namespace Fahrgemeinschaft;

public interface IDataStore
{
    void CreateRegistration(RegistrationViewModel registration);
}

public class MyDataStore : IDataStore
{
    private readonly string connectionString;

    public MyDataStore(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void CreateRegistration(RegistrationViewModel registration)
    {
        using MySqlConnection connection = new(connectionString);

        var entry = new
        {
            registration.FirstName,
            registration.LastName,
            registration.MailAddress,
            registration.BirthDate,
            registration.Password,
            
            
        };
        connection.Execute("INSERT INTO fahrgemeinschaft (FirstName, LastName, MailAddress, BirthDate, Password) VALUES (@FirstName, @LastName, @MailAddress, @BirthDate, @Password)", entry);

    }
}
