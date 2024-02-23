namespace Application.Abstractions.Responses {
    public interface IGenericPaginationResponse<T> {
        List<T> Items { get; set; }
        int TotalCount { get; set; }
        bool HasNext { get; set; }
    }
}
