using Domain.Services;
using MediatR;

namespace Application.Queries
{
    public class GetRandomJokeQueryHandler : IRequestHandler<GetRandomJokeQuery, string>
    {
        private readonly IJokeServiceFactory _jokeServiceFactory;

        public GetRandomJokeQueryHandler(IJokeServiceFactory jokeServiceFactory)
        {
            _jokeServiceFactory = jokeServiceFactory;
        }

        public async Task<string> Handle(GetRandomJokeQuery request, CancellationToken cancellationToken)
        {
            var service = _jokeServiceFactory.Create(request.Type);
            var result = await service.GetRandomJoke();
            return result.Text.Value;
        }
    }
}
