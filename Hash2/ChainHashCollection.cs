using System;
using System.Collections.Generic;
using System.Text;

namespace Hash2
{
    class ChainHashCollection<T>
    {
        List<T>[] elements;
        public readonly int Size;
        public int Count = 0;

        public ChainHashCollection(int size)
        {
            Size = size;
            elements = new List<T>[size];
        }

        int GetHash(T item)
        {
            double key = 0;
            if (typeof(T) == typeof(double) || typeof(T) == typeof(float) || typeof(T) == typeof(int))
                key = (double)(object)item;
            else if (typeof(T) == typeof(string))
                foreach (char el in item as string)
                    key += el;
            else
                key = item.GetHashCode();

            //return (int)(key*Size % Size);
            int hash = (int)key;
            for (int i = 1; i <= 50; i++)
                hash += (int)(key * Math.Pow(10, i)) - (int)(key * Math.Pow(10, i - 1)) * 10;
            return Math.Abs(hash % Size);
        }

        public void Add(T item)
        {
            int hash = GetHash(item);
            if (elements[hash] == null)
                elements[hash] = new List<T> { item };
            else
                elements[hash].Add(item);

            Count++;
        }
        public bool Remove(T item)
        {
            int hash = GetHash(item);

            if (elements[hash] == null)
                return false;
            else
                for (int i = 0; i < elements[hash].Count; i++)
                    if (elements[hash][i].Equals(item))
                    {
                        elements[hash].RemoveAt(i);
                        if (elements[hash].Count == 0)
                            elements[hash] = null;
                        Count--;
                        return true;
                    }

            return false;
        }
        public List<T> GetElementsBy(int hash)
        {
            if (hash > 0 && hash < Size)
                return elements[hash];
            else
                throw new Exception("Неверный хэш");
        }
        public List<T> GetSameElements(T item)
        {
            return elements[GetHash(item)];
            HashSet<T> set = new HashSet<T>();
        }
        public bool Contains(T item)
        {
            int hash = GetHash(item);
            if (elements[hash] != null)
            {
                foreach (T el in elements[GetHash(item)])
                    if (el.Equals(item))
                        return true;

                return false;
            }
            else
            {
                return false;
            }
        }
        public T[] GetElements()
        {
            T[] output = new T[Count];
            int i = 0;
            foreach(List<T> list in elements)
                foreach(T el in list)
                {
                    output[i] = el;
                    i++;
                }

            return output;
        }
        public void Clear()
        {
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = null;
            }
        }

        public double GetLoadFactor()
        {
            int loadElNum = 0;
            foreach(List<T> el in elements)
                if (el != null)
                    loadElNum++;

            return Count / (double)loadElNum;
        }
        public double GetEffectiveness()
        {
            int perfectCount = (int)Math.Round(Count / (double)Size);
            if (perfectCount == 0)
                perfectCount = 1;
            int difference = 0;
            foreach (List<T> el in elements)
                if (el != null)
                    if (el.Count - perfectCount > 0)
                        difference += el.Count - perfectCount;

            return 1 - (double)difference / Count;
        }
        public int GetLenghtOfLongestList()
        {
            int maxLength = 0;
            foreach(List<T> el in elements)
                if (el != null && el.Count > maxLength)
                    maxLength = el.Count;

            return maxLength;
        }
        public int GetLenghtOfShortestList()
        {
            int minLength = Count;
            foreach (List<T> el in elements)
                if (el == null)
                    minLength = 0;
                else if (el.Count < minLength)
                    minLength = el.Count;

            return minLength;
        }
    }
}
