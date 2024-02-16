using MediatR;

namespace Application.Commands.Create
{
    public class CreateJokeCommand : IRequest<bool>
    {
        public string Text { get; }

        public CreateJokeCommand(string text)
        {
            Text = text;
        }
    }
}
