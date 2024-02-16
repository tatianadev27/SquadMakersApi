using Domain.Math.Entities;
using MediatR;

namespace Application.Math.Queries
{
    public class GetLCMQueryHandler : IRequestHandler<GetLCMQuery, int>
    {
            public GetLCMQueryHandler()
            {
            }
            public async Task<int> Handle(GetLCMQuery request, CancellationToken cancellationToken)
        {
            return LeastCommonMultipleResult.Calcular(request.Numbers);
        }
    }
}
