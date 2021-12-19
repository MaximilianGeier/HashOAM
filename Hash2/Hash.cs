using System;
using System.Collections.Generic;
using System.Text;

namespace Hash2
{
    class HashOAM
    {
        private readonly int M = 10000;
        public object[] HashTable { get; }
        private readonly bool[] Flags;

        public HashOAM()
        {
            HashTable = new object[M];
            Flags = new bool[M];
            ResetFlags();
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
            do
            {
                int j = HashFunction(item, i);
                if(HashTable[j] is null || Flags[j])
                {
                    HashTable[j] = item;
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
            var h2 = 1 + item % (M - 3);
            return Convert.ToInt32((h1 + index * h2) % M);
        }
    }
}
