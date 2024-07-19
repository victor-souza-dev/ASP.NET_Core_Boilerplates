namespace Application.Abstractions.Filters {
    public interface IPagination {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
