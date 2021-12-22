using System;

namespace Hash2
{
    class Program
    {
        static void Main(string[] args)
        {
            HashOAM temp = new HashOAM();

            Random rnd = new Random();
            double[] nums = new double[10000];
            for (int i = 0; i < nums.Length; i++)
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

            ChainHashCollection<double> hashCol = new ChainHashCollection<double>(1000);

            foreach (double num in nums)
                hashCol.Add(num);

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
        }
    }
}
