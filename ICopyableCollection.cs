using System;
using System.Collections.Generic;
using System.Text;

namespace NobleMuffins.Collections
{
    public interface ICopyableCollection<T>
    {
        int Count { get; }
        void CopyTo(T[] array, int index);
    }
}
