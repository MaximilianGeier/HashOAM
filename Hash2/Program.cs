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
                nums[i] = (int)(rnd.NextDouble()*1000)+rnd.NextDouble();

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

            //Console.WriteLine(ChainHashCollection<double>.GetHash(1E-11) + " " + ChainHashCollection<double>.GetHash(1E-10));

            Console.WriteLine("Коэффициент заполнения:   " + hashCol.GetLoadFactor());
            Console.WriteLine("Процент эффективности:    " + Math.Round(100 * hashCol.GetEffectiveness()) + "%");
            Console.WriteLine("Длина кратчайшей цепочки: " + hashCol.GetLenghtOfShortestList());
            Console.WriteLine("Длина длиннейшей цепочки: " + hashCol.GetLenghtOfLongestList());

            /*Console.Write("Длины: [");
            foreach (int el in hashCol.GetChainLenghts())
                Console.Write(el + " ,");
            Console.Write("]");*/

            foreach (double num in nums)
                if (!hashCol.Remove(num))
                    throw new Exception("Хеш не совпал для одного и того же ключа");
            Console.WriteLine(hashCol.Count);
        }
    }
}
