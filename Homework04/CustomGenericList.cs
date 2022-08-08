using System;
using System.Collections;
using System.Collections.Generic;

namespace Homework04
{
    public class CustomGenericList<T> : IList<T>
    {
        private T[] _innerCollection;
        private int logLen = 0;
        private int allocLen = 4;

        public CustomGenericList()
        {
            _innerCollection = new T[allocLen];
        }
        
        //We haven't talked about lazy collections and enumerators, so I implemented few methods by myself
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _innerCollection)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            if (logLen >= allocLen)
            {
                allocLen *= 2;
                Array.Resize(ref _innerCollection, allocLen);
            }
            _innerCollection[logLen] = item;
            logLen++;
        }

        public void Clear()
        {
            allocLen = 4;
            _innerCollection = new T[allocLen];
            logLen = 0;
        }

        public bool Contains(T item)
        { 
            for(int i=0; i<logLen; i++)
            {
                if (_innerCollection[i].Equals(item)) return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < logLen; i++)
            {
                array[i] = _innerCollection[arrayIndex+i];
            }
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < logLen; i++)
            {
                if (_innerCollection[i].Equals(item))
                {
                    if (Count == 1 || i == logLen - 1)
                    {
                        logLen--;
                        return true;
                    }

                    for (int j=i; j<logLen; j++)
                    {
                        _innerCollection[j] = _innerCollection[j+1];
                    }
                    logLen--;
                    return true;
                }
            }
            return false;
        }

        public int Count { get => logLen; }
        
        //We are implementing read and write methods, so this one should be false
        public bool IsReadOnly => false;
        
        public int IndexOf(T item)
        {
            for (int i = 0; i < logLen; i++)
            {
                if (_innerCollection[i].Equals(item)) return i;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if(index < logLen)
            {
                _innerCollection[index] = item;
                return;
            }
            throw new ArgumentOutOfRangeException();
        }

        public void RemoveAt(int index)
        {
            if (index < logLen)
            {
                if(Count == 1 || index == logLen-1)
                {
                    logLen--;
                    return;
                }

                for (int j = index+1; j < logLen; j++)
                {
                    _innerCollection[j] = _innerCollection[j+1];
                }
                logLen--;
            }
            throw new ArgumentOutOfRangeException();
        }

        //Hint: here we should work with private collection that represents storage of items of the type T
        public T this[int index]
        {
            get
            {   if(index < logLen)
                    return _innerCollection[index];
                throw new ArgumentOutOfRangeException();
            } 
            set
            {
                if (index < logLen)
                    _innerCollection[index] = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}