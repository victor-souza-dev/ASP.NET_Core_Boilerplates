using Application.Abstractions.Filters;
using Application.Abstracts;
using Domain.Enums;

namespace Application.DTOs
{
    public class GenericPagination : IPagination, IFilter, IOrder
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
        public string Query { get; set; } = "";
        public string? OrderBy { get; set; }
        public OrderEnum? Order { get; set; } = OrderEnum.asc;
    }
}
