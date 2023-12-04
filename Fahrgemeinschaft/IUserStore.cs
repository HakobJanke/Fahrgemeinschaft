namespace Fahrgemeinschaft;
public interface IUserStore
{
    string[]? TryLoginUser(string Username, string Password);
}
public class StaticUserStore : IUserStore
{
    private readonly IReadOnlyCollection<User> users;

    public StaticUserStore(IReadOnlyCollection<User> users)
    {
        this.users = users;
    }
    public string[]? TryLoginUser(string Username, string Password)
    {
        return users.FirstOrDefault(user => user.Username == Username && user.Password == Password)?.Roles.ToArray();
    }
    public record User(string Username, string Password, IReadOnlyCollection<string> Roles);
}