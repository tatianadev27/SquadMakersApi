using Application.Queries;
using Domain.Math.Entities;
using Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Math.Queries
{
    public class GetPlusNumberHandler : IRequestHandler<GetPlusNumberQuery, int>
    {
            public GetPlusNumberHandler()
            {
            }

            public async Task<int> Handle(GetPlusNumberQuery request, CancellationToken cancellationToken)
        {
            return PlusNumberResult.Calcular(request.Number);
        }
    }
}
