using System.Collections.Generic;
using System.Collections;
using System.Text;
using System;

namespace NobleMuffins.Collections
{
    internal class ArrayEnumerator<T> : IEnumerator<T>, IEnumerator
    {
        private T[] array;
        private int index;

        public ArrayEnumerator(T[] array) {
            this.array = array;
            this.index = -1;
        }

        public T Current
        {
            get
            {
                return array[index];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return array[index];
            }
        }

        public void Dispose()
        {
            array = null;
        }

        public bool MoveNext()
        {
            bool moved;
            if (index < array.Length)
            {
                index++;
                moved = true;
            }
            else
            {
                moved = false;
            }
            return moved;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
