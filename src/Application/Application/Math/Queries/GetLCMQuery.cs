using MediatR;

namespace Application.Math.Queries
{
    public class GetLCMQuery : IRequest<int>
    {
        public List<int> Numbers { get; }

        public GetLCMQuery(List<int> numbers)
        {
            Numbers = numbers;
        }
    }
}
