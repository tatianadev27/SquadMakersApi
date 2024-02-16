namespace Domain.Entities
{
    public class JokeText
    {
        public string Value { get; }

        public JokeText(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Joke text cannot be null or empty.", nameof(value));

            Value = value;
        }
    }
}
