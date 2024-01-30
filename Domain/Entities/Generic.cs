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

public class GenericPagination {
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
    public string Query { get; set; } = "";
    public string SortField { get; set; } = "name";
    public SortDirectionEnum SortDirection { get; set; } = SortDirectionEnum.asc;
}