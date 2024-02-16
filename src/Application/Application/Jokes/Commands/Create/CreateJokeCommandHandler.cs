using Domain.Aggregate;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Commands.Create
{
    public class CreateJokeCommandHandler : IRequestHandler<CreateJokeCommand, string>
    {
        private readonly IJokeRepository _jokeRepository;

        public CreateJokeCommandHandler(IJokeRepository jokeRepository)
        {
            _jokeRepository = jokeRepository;
        }

        public async Task<string> Handle(CreateJokeCommand request, CancellationToken cancellationToken)
        {
            var joke = Joke.Create(new JokeText(request.Text));
            await _jokeRepository.Add(joke);
            return joke.Id.Value.ToString();
        }
    }
}
