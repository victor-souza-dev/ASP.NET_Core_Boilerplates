using Domain.Entities;

namespace Application.Abstractions.Responses;

public class PaginationResponse<T> {
    public List<T> Items { get; set; } = new List<T>();
    public int TotalCount { get; set; } = 0;
    public bool HasNext { get; set; } = false;
}

public class UserPaginationResponse : PaginationResponse<User> {
}