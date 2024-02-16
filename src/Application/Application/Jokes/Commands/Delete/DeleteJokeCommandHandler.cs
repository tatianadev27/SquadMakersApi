using Domain.Aggregate;
using Domain.Repositories;
using MediatR;

namespace Application.Jokes.Commands.Delete
{
    public class DeleteJokeCommandHandler : IRequestHandler<DeleteJokeCommand, bool>
    {
        private readonly IJokeRepository _jokeRepository;

        public DeleteJokeCommandHandler(IJokeRepository jokeRepository)
        {
            _jokeRepository = jokeRepository;
        }

        public async Task<bool> Handle(DeleteJokeCommand request, CancellationToken cancellationToken)
        {
            var existingJoke = await _jokeRepository.GetById(new Domain.Entities.JokeId(request.Id));
            if (existingJoke == null)
                return false;

            var joke = Joke.Delete(existingJoke);
            return await _jokeRepository.Delete(joke.Id);
        }
    }
}
