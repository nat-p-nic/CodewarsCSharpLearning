namespace Kata.Library
{
    public static class JosephusSurvivor
    {
        // https://www.codewars.com/kata/555624b601231dc7a400017a/train/csharp

        public static int JosSurvivor(int n, int k)
        {
            if (n == 1)
                return 1;
            if (k == 1)
                return n;

            bool[] survivors = Enumerable.Repeat(true, n).ToArray();

            int currentPosition = 0;
            int remaining = n;
            while (remaining > 1)
            {
                int steps = (k - 1) % remaining;
                for (int i = 0; i < steps; i++)
                {
                    // Unrolled method here and below for speed increase - DRY?
                    do
                    {
                        currentPosition++;
                        if (currentPosition >= survivors.Length)
                            currentPosition = 0;
                    } while (!survivors[currentPosition]);
                }

                survivors[currentPosition] = false;
                remaining--;

                if (remaining > 0)
                {
                    do
                    {
                        currentPosition++;
                        if (currentPosition >= survivors.Length)
                            currentPosition = 0;
                    } while (!survivors[currentPosition]);
                }
            }

            return currentPosition + 1;
        }
    }
}