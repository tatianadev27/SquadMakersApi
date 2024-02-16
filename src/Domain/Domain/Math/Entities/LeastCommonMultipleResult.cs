namespace Domain.Math.Entities
{
    public class LeastCommonMultipleResult
    {
        private LeastCommonMultipleResult() { }

        // Complexity O(log(min(a, b)))
        public static int Calculate(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                throw new ArgumentException("Array of numbers cannot be null or empty.");
            }

            int lcm = numbers[0];

            for (int i = 1; i < numbers.Count; i++)
            {
                lcm = CalculateLCM(lcm, numbers[i]);
            }

            return lcm;
        }
        private static int CalculateLCM(int a, int b)
        {
            return (a * b) / GCD(a, b);
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

    }
}
