namespace Domain.Math.Entities
{
    public class PlusNumberResult
    {
        private PlusNumberResult() { }

        // Complexity O(1)
        public static int Calculate(int number) => number+1;
    }
}
