using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NobleMuffins.Collections
{
    public class Array<T> : ICopyableCollection<T>, IEnumerable<T>
    {
        private readonly T[] array;

        public Array(ICopyableCollection<T> source)
        {
            if (source == null)
            {
                throw new ArgumentException();
            }
            array = new T[source.Count];
            source.CopyTo(array, 0);
        }

        public Array(T[] source)
        {
            if (source == null)
            {
                throw new ArgumentException();
            }
            this.array = source;
        }

        public int Count
        {
            get
            {
                return array.Length;
            }
        }

        public void CopyTo(T[] destination, int index)
        {
            if (array.Length + index > destination.Length)
            {
                throw new ArgumentException();
            }
            System.Array.Copy(array, 0, destination, index, array.Length);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ArrayEnumerator<T>(array);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ArrayEnumerator<T>(array);
        }
    }
}
