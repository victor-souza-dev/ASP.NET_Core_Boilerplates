using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    public User(string name, string email, string password)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Password = password;
    }
}
