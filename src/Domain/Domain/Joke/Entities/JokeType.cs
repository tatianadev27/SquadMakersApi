namespace Domain.Entities
{
    public class JokeType
    {
        public string Value { get; }

        public JokeType(string value)
        {
            Value = value;
        }

        public static JokeType Chuck => new JokeType("Chuck");
        public static JokeType Dad => new JokeType("Dad");
    }
}
