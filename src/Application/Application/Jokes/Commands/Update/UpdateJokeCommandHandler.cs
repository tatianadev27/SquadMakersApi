using Application.Commands.Update;
using Domain.Aggregate;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Jokes.Commands.Update
{
    public class UpdateJokeCommandHandler : IRequestHandler<UpdateJokeCommand, bool>
    {
        private readonly IJokeRepository _jokeRepository;

        public UpdateJokeCommandHandler(IJokeRepository jokeRepository)
        {
            _jokeRepository = jokeRepository;
        }

        public async Task<bool> Handle(UpdateJokeCommand request, CancellationToken cancellationToken)
        {
            var existingJoke = await _jokeRepository.GetById(request.Id);
            if (existingJoke == null)
                return false;
            var joke = Joke.Update(existingJoke, new JokeText(request.Text));
            return await _jokeRepository.Update(joke);
        }
    }
}
