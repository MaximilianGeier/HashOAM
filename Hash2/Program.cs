using System;
using System.Collections.Generic;

namespace Hash2
{
    class Program
    {
        static void Main(string[] args)
        {
            HashOAM hash2 = new HashOAM();

            Random rnd = new Random();
            double[] nums = new double[9000];
            for (int i = 0; i < nums.Length; i++)
                nums[i] = rnd.NextDouble() *(rnd.Next(9)+1);

            foreach (var item in nums)
                hash2.Insert(item);

            List<int> average = new List<int>();
            int maxLen = 0;
            int currentLen = 0;
            for (int i = 0; i < hash2.HashTable.Length; i++)
            {
                if (hash2.HashTable[i] != null)
                    currentLen++;
                else
                {
                    if (currentLen > maxLen)
                        maxLen = currentLen;
                    currentLen = 0;
                    if (currentLen > 0)
                        average.Add(currentLen);
                }
            }

            //Console.WriteLine(temp.MaxLength);

            ChainHashCollection<double> hashCol = new ChainHashCollection<double>(1000);

            foreach (double num in nums)
                hashCol.Add(num);

            Console.WriteLine("Коэффициент заполнения:   " + hashCol.GetLoadFactor());
            Console.WriteLine("Процент эффективности:    " + Math.Round(100 * hashCol.GetEffectiveness()) + "%");
            Console.WriteLine("Длина кратчайшей цепочки: " + hashCol.GetLenghtOfShortestList());
            Console.WriteLine("Длина длиннейшей цепочки: " + hashCol.GetLenghtOfLongestList());

            Console.WriteLine("___________________________________");
            Console.WriteLine("Максимальная длина цепи: " + maxLen);
            Console.WriteLine("Среднее количество переходов: " + hash2.GetAverageLen());
            Console.WriteLine("Максимальное количество переходов: " + hash2.GetMaxChainLen());
        }
    }
}
