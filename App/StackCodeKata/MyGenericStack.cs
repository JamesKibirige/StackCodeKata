using System;
using System.Linq;

namespace StackCodeKata
{
    public class MyGenericStack<T>
    {
        private readonly int _limit;
        private readonly T[] _collection;

        public MyGenericStack(int limit)
        {
            if (limit < 0)
            {
                throw new ArgumentOutOfRangeException($"Cannot create negative sized Stack, {nameof(limit)} must be at least 0");
            }
            _limit = limit;
            _collection = new T[_limit];
        }

        public int Size { get; set; }

        public void Push(T item)
        {
            if (Size == _limit)
            {
                throw new OverflowException();
            }

            _collection[Size] = item;

            Size++;
        }

        public T Pop()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("There are no elements on the stack to Pop!");
            }

            var result = _collection[Size - 1];
            Size--;

            return result;
        }

        public T Peek()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("There are no elements on the stack to Peek!");
            }
            return _collection[Size - 1];
        }

        public T Find(T item)
        {
            return _collection.FirstOrDefault(c => c.Equals(item));
        }
    }
}