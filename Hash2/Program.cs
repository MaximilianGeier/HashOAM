using System;

namespace Hash2
{
    class Program
    {
        static void Main(string[] args)
        {
            HashOAM temp = new HashOAM();

            Random rnd = new Random();
            double[] nums = new double[100000];
            for (int i = 0; i < nums.Length; i++)
                nums[i] = rnd.NextDouble()*(rnd.Next(9)+1);

            /*foreach (var item in nums)
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
            Console.WriteLine(maxLen);*/

            ChainHashCollection<double> hashCol = new ChainHashCollection<double>(1000);

            foreach (double num in nums)
                hashCol.Add(num);

            Console.WriteLine("Коэффициент заполнения:   " + hashCol.GetLoadFactor());
            Console.WriteLine("Процент эффективности:    " + Math.Round(100 * hashCol.GetEffectiveness()) + "%");
            Console.WriteLine("Длина кратчайшей цепочки: " + hashCol.GetLenghtOfShortestList());
            Console.WriteLine("Длина длиннейшей цепочки: " + hashCol.GetLenghtOfLongestList());
        }
    }
}
