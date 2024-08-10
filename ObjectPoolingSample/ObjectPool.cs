using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPoolingSample
{
    internal class ObjectPool<T> where T : new()
    {
        private readonly Stack<T> _pool;

        public ObjectPool(int initialCapacity)
        {
            _pool = new Stack<T>(initialCapacity);

            for(var i = 0; i < initialCapacity; i++)
            {
                _pool.Push(new T());
            }
        }

        public T GetObject()
        {
            if (_pool.Any())
            {
                return _pool.Pop();
            }

            return new T();
        }

        public void ReturnObject(T obj)
        {
            _pool.Push(obj);
        }

        public int Count => _pool.Count;    
    }
}
