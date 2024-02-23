using Application.Abstractions.Filters;
using Application.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Requests
{
    public interface IGenericPaginationRequest : IPagination, IFilter, IOrder
    {
    }
}
