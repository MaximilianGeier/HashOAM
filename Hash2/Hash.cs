using System;
using System.Collections.Generic;
using System.Text;

namespace Hash2
{
    class HashOAM
    {
        public object[] HashTable { get; }
        private readonly int M = 10000;
        private readonly List<int> Average = new List<int>();
        private readonly bool[] Flags;

        public HashOAM()
        {
            HashTable = new object[M];
            Flags = new bool[M];
            ResetFlags();
        }

        public double GetAverageLen()
        {
            int sum = 0;
            foreach (var item in Average)
                sum += item;
            return (double)sum / Average.Count;
        }

        public int GetMaxChainLen()
        {
            int maxNum = 0;
            foreach (var item in Average)
            {
                if (item > maxNum)
                    maxNum = item;
            }
            return maxNum;
        }

        private void ResetFlags()
        {
            for (int i = 0; i < M; i++)
            {
                Flags[i] = false;
            }
        }

        public int Insert(double item)
        {
            int i = 0;
            int j;
            do
            {
                j = HashFunction(item, i);
                if(HashTable[j] is null || Flags[j])
                {
                    HashTable[j] = item;
                    Average.Add(i + 1);
                    return j;
                }
                else
                {
                    i++;
                }
            } while (i < M);
            throw new Exception("Хеш таблица заполнена");
        }

        public object Search(double item)
        {
            int i = 0;
            int j;
            do
            {
                j = HashFunction(item, i);
                if(HashTable[j] != null)
                {
                    if ((double)HashTable[j] == item && !Flags[j])
                        return j;
                }
                i++;
            } while (HashTable[j] == null || i < M);
            return null;
        }
        public void Remove(double item)
        {
            Flags[(int)Search(item)] = true;
        }

        private int HashFunction(double item, int index)
        {
            var h1 = item % M;
            var h2 = item * M % M;
            return (int)(h1 + h2 + index * Math.PI) % M;
        }
    }
}
