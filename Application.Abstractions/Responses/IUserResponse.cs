using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Responses {
    public interface IUserResponse {
        Guid Id { get; }
        string Name { get; }
        string Email { get; }
    }
}
