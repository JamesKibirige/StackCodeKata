using System;
using System.Linq;

namespace StackCodeKata
{
    public class MyStack
    {
        private readonly int _limit;
        private readonly string[] _collection;

        public MyStack(int limit)
        {
            if (limit < 0)
            {
                throw new ArgumentOutOfRangeException($"Cannot create negative sized Stack, {nameof(limit)} must be at least 0");
            }
            _limit = limit;
            _collection = new string[_limit];
        }

        public int Size { get; set; }

        public void Push(string item)
        {
            if (Size == _limit)
            {
                throw new OverflowException();
            }

            _collection[Size] = item;

            Size++;
        }

        public string Pop()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("There are no elements on the stack to Pop!");
            }

            var result = _collection[Size - 1];
            Size--;

            return result;
        }

        public string Peek()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("There are no elements on the stack to Peek!");
            }
            return _collection[Size - 1];
        }

        public string Find(string item)
        {
            return _collection.FirstOrDefault(c => c == item);
        }
    }
}