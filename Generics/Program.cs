using System;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
           

            //Console.WriteLine($"{a}{b}");
        }

        class GenericCollection<T>
        {
            T[] Items;

            public GenericCollection()
            {
                Items = new T[20];
            }

            public T GetItem(T[] arr, int index)
            {
                return arr[index];
            }
            public void SetItem(T[] arr, T item, int index)
            {
                arr[index] = item;
            }
            public void Swap(T a, T b)
            {
                (a, b) = (b, a);
            }

            public void Swap(T[] arr, int firstIndex, int secondIndex)
            {
                (arr[firstIndex], arr[secondIndex]) = (arr[secondIndex], arr[firstIndex]);
            }
        }
    }
}
