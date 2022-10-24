using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Collections;
namespace lab09
{
    class Services : IOrderedDictionary
    {
        Queue type;
        public Services()
        {
            type = new Queue(10);
        }
        public Services(int number)
        {
            type = new Queue(number);
        }
        public void Add(object key, object value)
        {
            type.Enqueue(new DictionaryEntry(key, value));
        }
        public int Count
        {
            get
            {
                return type.Count;
            }
        }
        public bool IsSynchronized
        {
            get
            {
                return type.IsSynchronized;
            }
        }
        public object SyncRoot
        {
            get
            {
                return type.SyncRoot;
            }
        }
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        public ICollection Values
        {
            get
            {
                Queue temp = type;
                Queue valueQueue = new Queue(type.Count);
                for (int i = 0; i < temp.Count; i++)
                {
                    valueQueue.Enqueue(((DictionaryEntry)type.Dequeue()).Value);
                }
                type = temp;
                return valueQueue;
            }
        }
        public ICollection Keys
        {
            get
            {
                object[] temp = new object[type.Count];
                object[] tmp = type.ToArray();
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = ((DictionaryEntry)tmp[i]).Key;
                }
                return temp;
            }
        }
        public int IndexOfKey(object key)
        {
            object[] tmp=type.ToArray();
            for (int i = 0; i < tmp.Length; i++)
            {
                
                if ((int)(((DictionaryEntry)tmp[i]).Key) == (int)key)
                {
                    return i;
                }
            }
            return -1;
            }
        public object this[object key]
        {
            get
            {
                int tmp = IndexOfKey(key);
                Queue result = new Queue();
                Queue temp = type;
                for (int i = 0; i < type.Count; i++)
                {
                    if (tmp == i)
                    {
                        result.Enqueue(temp.Dequeue());
                    }
                    temp.Dequeue();
                }
                return ((DictionaryEntry)result.Dequeue()).Value;
            }
            set
            {
                int tmp = IndexOfKey(key);
                Queue result = new Queue();
                Queue temp = type;
                for (int i = 0; i < temp.Count; i++)
                {

                    if (tmp == i)
                    {
                        type.Dequeue();
                        type.Enqueue(new DictionaryEntry(key, value));//
                    }
                    type.Dequeue();
                }
            }
        }

        public object this[int index]
        {
            get
            {
                Queue result = new Queue();
                Queue temp = type;
                for (int i = 0; i < type.Count; i++)
                {

                    if (index == i)
                    {
                        result.Enqueue(temp.Dequeue());
                    }
                    temp.Dequeue();
                }
                return ((DictionaryEntry)result.Dequeue()).Value;
            }
            set
            {
                Queue result = new Queue();
                Queue temp = type;
                for (int i = 0; i < type.Count; i++)
                {

                    if (index == i)
                    {
                        result.Enqueue(temp.Dequeue());
                    }
                    temp.Dequeue();
                }
                object key = ((DictionaryEntry)result.Dequeue()).Key;
                temp = type;
                for (int i = 0; i < temp.Count; i++)
                {

                    if (index == i)
                    {
                        type.Enqueue(new DictionaryEntry(key, value));      
                        break;
                    }
                    type.Dequeue();
                }
            }
        }
        public void RemoveAt(int index)
        {
            Queue temp = type;
            object[] tmp = new object[temp.Count];
                tmp=temp.ToArray();
            for (int i = 0; i < tmp.Length; i++)
            {
                if (i == index)
                {
                    tmp[index] = tmp[i+1];
                    
                }
            }
        }
        public void Clear()
        {
            type.Clear();
        }
        public void Remove(object key)
        {
            RemoveAt(IndexOfKey(key));
        }
        public void CopyTo(Array arr,int index)
        {
            object[] temp = type.ToArray();
            temp.CopyTo(arr, index);
        }
        public void Insert(int index, object key, object value)
        {
            if (IndexOfKey(key) != -1)
            {
                throw new ArgumentException("An element with the same key already exists in the collection.");
            }
            object[] tmp = type.ToArray();
            object[] temp = new object[type.Count + 1];
            int counter = 0;
            for (int i = 0; i < tmp.Length; i++)
            {

                if (index != i)
                {
                    temp[counter++] = tmp[i];
                }
                else
                {
                    temp[counter++] = new DictionaryEntry(key, value);
                    temp[counter++] = tmp[i];
                }                                       
            }
            for (int i = 0; i < tmp.Length; i++)
            {
                type.Dequeue();
            }
            for (int i = 0; i < temp.Length; i++)
            {
                type.Enqueue(temp[i]);
            }

        }
        public IDictionaryEnumerator GetEnumerator()
        {
            return new TypeEnum(type);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new TypeEnum(type);
        }
        public bool Contains(object key)
        {
            if (IndexOfKey(key) != -1)
            {
                return true;
            }
            return false;
        }
    }
    public class TypeEnum : IDictionaryEnumerator
    {
        public Queue type;
        int position = -1;
        public TypeEnum(Queue _type)
        {
            type = _type;
        }
        public bool MoveNext()
        {
            position++;
            return (position < type.Count);
        }
        public void Reset()
        {
            position = -1;
        }
        public object Current
        {
            get
            {
                try
                {
                    Queue result = new Queue();
                    Queue temp = type;
                    for (int i = 0; i < temp.Count; i++)
                    {

                        if (position == i)
                        {
                            result.Enqueue(temp.Dequeue());
                        }
                        temp.Dequeue();
                    }
                    return result.Dequeue();
                }
                catch(IndexOutOfRangeException)
                {
                    throw new InvalidCastException();
                }
            }
        }
        public DictionaryEntry Entry
        {
            get
            {
                return (DictionaryEntry)Current;
            }
        }
        public object Value
        {
            get
            {
                try
                {
                    Queue tmp = type;
                    Queue res = new Queue();
                    for (int i = 0; i < type.Count; i++)
                    {
                        tmp.Dequeue();
                        if (i == position)
                        {
                            res.Enqueue(tmp.Dequeue());
                        }
                    }
                    return (((DictionaryEntry)res.Dequeue()).Value);
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
        public object Key
        {
            get
            {
                try
                {
                    Queue tmp = type;
                    Queue res = new Queue();
                    for (int i = 0; i < type.Count; i++)
                    {
                        tmp.Dequeue();
                        if (i == position)
                        {
                            res.Enqueue(tmp.Dequeue());
                        }
                    }
                    return (((DictionaryEntry)res.Dequeue()).Key);
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }   



    class Program
    {
        static void Main(string[] args)
        {
            OrderedDictionary orderedDictionary = new OrderedDictionary();
            orderedDictionary.Add(10, 1231);
            orderedDictionary.Add(2, 441);
            orderedDictionary.Add(3, 777);
            orderedDictionary.Add(4, 222);
            orderedDictionary.Add(5, 666);
            DictionaryEntry[] array2 = new DictionaryEntry[orderedDictionary.Count];
            orderedDictionary.CopyTo(array2, 0);


            Services services = new Services();
            services.Add(10, 1231);
            services.Add(2, 441);
            services.Add(3, 777);
            services.Add(4, 222);
            services.Add(5, 666);
            bool contain=services.Contains(2);
            DictionaryEntry[] array = new DictionaryEntry[services.Count];
            int count = services.Count;
            services.CopyTo(array, 0);
            int index = services.IndexOfKey(3);
            services.Insert(1,121,222228888);
            bool IsFixedSize=services.IsFixedSize;
            bool IsReadOnly=services.IsReadOnly;
            bool IsSync=services.IsSynchronized;
            var key=services.Keys;
          
            
            
            
            
            
            
            
            
            services.Clear();

           
            
        }
    }
}
