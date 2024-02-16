using Domain.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace Domain.Aggregate
{
    public class Joke
    {
        public JokeId Id { get; }
        public JokeText Text { get; private set; }

        private Joke(JokeId id, JokeText text)
        {
            Id = id;
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }
        public static Joke Create(JokeText text, JokeId id = null) => new Joke(id, text);
        public static Joke Delete(Joke joke)
        {
            if (joke.Id == null) throw new ArgumentNullException(nameof(joke.Id));
            return new Joke(joke.Id, joke.Text);
        }

        public static Joke Update(Joke joke, JokeText newText)
        {
            if (joke.Id == null) throw new ArgumentNullException(nameof(joke.Id));
            if (newText == null) throw new ArgumentNullException(nameof(newText));
            joke.Text = newText;
            return joke;
        }

        public static Joke GetRamdom()
        {
            Dictionary<int, string> jokes = new Dictionary<int, string>
        {
            { 1, "¿Por qué los pájaros no usan Facebook? Porque ya tienen Twitter." },
            { 2, "¿Qué hace una abeja en el gimnasio? ¡Zum-ba!" },
            { 3, "¿Qué le dice una iguana a su hermana gemela? ¡Iguanita!" },
            { 4, "¿Qué le dice Tarzán a Cenicienta? ¡Ven, que te echo un cuento!" },
            { 5, "¿Por qué los astronautas no pueden tomar Coca-Cola? Porque están en el espacio." }
        };

            Random random = new Random();
            int randomKey = random.Next(1, jokes.Count + 1);
            return Create(new JokeText(jokes[randomKey]));
        }
    }
}
