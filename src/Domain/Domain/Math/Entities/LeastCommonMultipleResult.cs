namespace Domain.Math.Entities
{
    public class LeastCommonMultipleResult
    {
        private LeastCommonMultipleResult() { }

        // Complexity O(n * log(n) * log(log(n)))
        public static int Calcular(List<int> numeros)
        {
            int mcd = numeros[0];
            for (int i = 1; i < numeros.Count; i++)
            {
                mcd = CalcularMCDLehmer(mcd, numeros[i]);
            }

            int lcm = 1;
            foreach (int numero in numeros)
            {
                lcm *= numero / mcd;
            }

            return lcm;
        }

        public static int CalcularMCDLehmer(int a, int b)
        {
            int u = a, v = b, t = 1, s = 0;

            while (u != 0)
            {
                while ((u & 1) == 0)
                {
                    u >>= 1;
                    if ((t & 1) != 0)
                    {
                        t += v;
                    }
                    t >>= 1;
                }

                while ((v & 1) == 0)
                {
                    v >>= 1;
                    if ((s & 1) != 0)
                    {
                        s += u;
                    }
                    s >>= 1;
                }

                if (u >= v)
                {
                    u -= v;
                }
                else
                {
                    v -= u;
                }
            }

            return v;
        }

    }
}
