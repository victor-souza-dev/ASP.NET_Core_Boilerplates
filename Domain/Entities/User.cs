namespace Domain.Entities;

public class User: GenericIdGuid
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    public User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }

    public void Update(string name, string email, string password) {
        Name = name;
        Email = email;
        Password = password;
    }
}
