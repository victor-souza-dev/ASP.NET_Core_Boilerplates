using Domain.Enums;

namespace Domain.Entities;

public class Generic
{
    public DateTime CreateNow { get; private set; }
}

public class GenericIdGuid : Generic
{
    public Guid Id { get; private set; }
    public GenericIdGuid()
    {
        Id = Guid.NewGuid();
    }
}

public class GenericIdInt : Generic
{
    public int Id { get; private set; }
}