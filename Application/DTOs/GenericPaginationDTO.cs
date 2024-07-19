using Application.Abstractions.Requests;
using Application.Abstractions.Responses;
using Domain.Enums;

namespace Application.DTOs {
    public class GenericPaginationRequest : IGenericPaginationRequest {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
        public string Query { get; set; } = "";
        public string? OrderBy { get; set; }
        public OrderEnum? Order { get; set; } = OrderEnum.asc;
    }
}
