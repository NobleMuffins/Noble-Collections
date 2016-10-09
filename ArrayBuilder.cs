using System;
using System.Collections.Generic;
using System.Text;

namespace NobleMuffins.Collections
{
    public class ArrayBuilder<T> : ICopyableCollection<T>
    {
        private T[] array;
        private int count;

        public ArrayBuilder(): this(16)
        {
        }

        public ArrayBuilder(int initialCapacity)
        {
            array = new T[initialCapacity];
        }

        public void Add(T datum)
        {
            var newCount = count + 1;
            EnsureCapacity(newCount);
            array[count] = datum;
            count = newCount;
        }

        public void Add(T[] data)
        {
            var newCount = count + data.Length;
            EnsureCapacity(newCount);
            System.Array.Copy(data, 0, array, count, data.Length);
            count = newCount;
        }

        public void Add(ICopyableCollection<T> copyable)
        {
            var newCount = count + copyable.Count;
            EnsureCapacity(newCount);
            copyable.CopyTo(array, count);
            count = newCount;
        }

        public void Add(IEnumerable<T> enumerable)
        {
            foreach (var datum in enumerable)
            {
                Add(datum);
            }
        }

        private void EnsureCapacity(int newCount)
        {
            if (count > array.Length)
            {
                var newCapacity = ArrayBuilder<T>.RoundUp(newCount);
                System.Array.Resize(ref array, newCount);
            }
        }

        public int Count { get; private set; }

        public void CopyTo(T[] destination, int index)
        {
            if (count + index > destination.Length)
            {
                throw new ArgumentException();
            }
            System.Array.Copy(array, 0, destination, index, count);
        }

        private static int RoundUp(int figure)
        {
            int i = 1;
            while (i < figure)
            {
                i *= 2;
            }
            return i;
        }
    }
}
