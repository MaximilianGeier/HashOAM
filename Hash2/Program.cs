using System;

namespace Hash2
{
    class Program
    {
        static void Main(string[] args)
        {
            HashOAM temp = new HashOAM();

            Random rnd = new Random();
            double[] nums = new double[9000];
            for (int i = 0; i < nums.Length; i++)
                nums[i] = rnd.NextDouble();

            foreach (var item in nums)
                temp.Insert(item);

            int maxLen = 0;
            int currentLen = 0;
            for(int i = 0; i < temp.HashTable.Length; i++)
            {
                if (temp.HashTable[i] != null)
                    currentLen++;
                else
                {
                    if (currentLen > maxLen)
                        maxLen = currentLen;
                    currentLen = 0;
                }
            }
            Console.WriteLine(maxLen);
        }
    }
}
