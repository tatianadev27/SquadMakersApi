using MediatR;
namespace Application.Queries
{
    public class GetRandomJokeQuery : IRequest<string?>
    {
        public string? Type { get; }

        public GetRandomJokeQuery(string? type)
        {
            Type = type;
        }
    }
}
