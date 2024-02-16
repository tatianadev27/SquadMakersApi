using MediatR;

namespace Application.Math.Queries
{
    public class GetPlusNumberQuery : IRequest<int>
    {
        public int Number { get; }

        public GetPlusNumberQuery(int number)
        {
            Number = number;
        }
    }
}
