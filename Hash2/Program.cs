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
            double[] nums = new double[10000];
            for (int i = 0; i < nums.Length; i++)
<<<<<<< HEAD
                nums[i] = (rnd.NextDouble() * 1000);

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

            //DoForChainCollection();
        }

        static void DoForChainCollection()
        {
            Random rnd = new Random();
            double[] nums = new double[10000];
            for (int i = 0; i < nums.Length; i++)
                nums[i] = (rnd.NextDouble() * 1000);
=======
                nums[i] = rnd.NextDouble() *(rnd.Next(9)+1);

            foreach (var item in nums)
                hash2.Insert(item);
>>>>>>> master

            ChainHashCollection<double> hashCol = new ChainHashCollection<double>(1000);

            foreach (double num in nums)
                hashCol.Add(num);

<<<<<<< HEAD
            Console.WriteLine();
            Console.WriteLine("    Коэффициент заполнения:   " + hashCol.GetLoadFactor());
            Console.WriteLine("    Процент эффективности:    " + Math.Round(100 * hashCol.GetEffectiveness()) + "%");
            Console.WriteLine("    Длина кратчайшей цепочки: " + hashCol.GetLenghtOfShortestList());
            Console.WriteLine("    Длина длиннейшей цепочки: " + hashCol.GetLenghtOfLongestList());

            /*Console.Write("Длины: [");
            foreach (int el in hashCol.GetChainLenghts())
                Console.Write(el + " ,");
            Console.Write("]");*/

            hashCol.GetElementsBy(2);
            foreach (double num in nums)
                if (!hashCol.Remove(num))
                    throw new Exception("Хеш не совпал для одного и того же ключа");
=======
            Console.WriteLine("Коэффициент заполнения:   " + hashCol.GetLoadFactor());
            Console.WriteLine("Процент эффективности:    " + Math.Round(100 * hashCol.GetEffectiveness()) + "%");
            Console.WriteLine("Длина кратчайшей цепочки: " + hashCol.GetLenghtOfShortestList());
            Console.WriteLine("Длина длиннейшей цепочки: " + hashCol.GetLenghtOfLongestList());

            Console.WriteLine("___________________________________");
            Console.WriteLine("Максимальная длина цепи: " + hash2.GetMaxLen());
            Console.WriteLine("Среднее количество переходов: " + hash2.GetAverageLen());
            Console.WriteLine("Максимальное количество переходов: " + hash2.GetMaxChainLen());
>>>>>>> master
        }
    }
}
