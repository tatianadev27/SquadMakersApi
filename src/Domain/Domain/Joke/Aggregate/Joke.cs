using Domain.Entities;

namespace Domain.Aggregate
{
    public class Joke
    {
        public JokeId Id { get; }
        public JokeText Text { get; }

        private Joke(JokeId id, JokeText text)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        private Joke(JokeText text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public void SetJokeText(JokeText Text) => Text = Text;


        public static Joke Create(JokeText text) => new Joke(text);
        public static Joke Delete(Joke joke) => new Joke(joke.Id, joke.Text);
        public static Joke Bulid(JokeText text) => new Joke(text);
        public static Joke Update(JokeId id, JokeText text) => new Joke(id, text);
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
            return Bulid(new JokeText(jokes[randomKey]));
        }
    }
}
