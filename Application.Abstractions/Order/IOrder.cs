using Domain.Enums;

namespace Application.Abstracts {
    public interface IOrder {
        string? OrderBy { get; set; }
        OrderEnum? Order { get; set; }
    }
}