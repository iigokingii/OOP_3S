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
                object[] temp = new object[type.Count];
                object[] tmp = type.ToArray();
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = ((DictionaryEntry)tmp[i]).Value;
                }
                return temp;
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
                object[] temp = type.ToArray();
                return ((DictionaryEntry)temp[IndexOfKey(key)]).Value;
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
                object[] temp = type.ToArray();
                return ((DictionaryEntry)temp[index]).Value;
            }
            set
            {
                Insert(index, index, value);               
            }
        }
        public void RemoveAt(int index)
        {
            object[] tmp = type.ToArray();
            object[] temp = new object[type.Count -1];
            int counter = 0;
            for (int i = 0; i < tmp.Length; i++)
            {

                if (index != i)
                {
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
                    object[]tmp=type.ToArray();
                    return tmp[position];
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
                    object[] tmp = type.ToArray();
                    return ((DictionaryEntry)tmp[position]).Value;
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
    class ToRuleCollection
    {
        Queue queue;
        public ToRuleCollection()
        {
            queue = new Queue();
        }
        public ToRuleCollection(int _number)
        {
            queue = new Queue(_number);
        }
        public void Add(Services serv)
        {
            queue.Enqueue(serv);
        }
        public void Insert(int index,Services serv)
        {
            object[] temp=queue.ToArray();
            object[] tmp = new object[temp.Length+1];
            int counter = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                if (i != index)
                {
                    tmp[counter++] = temp[i];
                }
                else
                {
                    tmp[counter++] = serv;
                    tmp[counter++] = temp[i];
                }
            }
            for (int i = 0; i < temp.Length; i++)
            {
                queue.Dequeue();
            }
            for (int i = 0; i < tmp.Length; i++)
            {
                queue.Enqueue(tmp[i]);
            }
        }
        public void Clear()
        {
            queue.Clear();
        }
        
        public Services Find(int index)
        {
            object[] temp=queue.ToArray();
            return (Services)temp[index];
        }
    }











    class Program
    {
        static void Main(string[] args)
        {
            Services services = new Services();
            services.Add(10, 1231);
            services.Add(2, 441);
            services.Add(3, 777);
            services.Add(4, 222);
            services.Add(5, 666);

            foreach (var temp in services)
            {
                Console.WriteLine($"key: {((DictionaryEntry)temp).Key}-->value: {((DictionaryEntry)temp).Value}");
            }
            Console.WriteLine();

            bool contain = services.Contains(2);
            if (contain)
                Console.WriteLine("includes key 2");
            else
                Console.WriteLine("doesn't include");
            Console.WriteLine() ;
            
            int count = services.Count;
            Console.WriteLine($"Services includes {count} elem");
            Console.WriteLine();
            
            DictionaryEntry[] array = new DictionaryEntry[services.Count];
            services.CopyTo(array, 0);
            foreach (object temp in array)
            {
                Console.WriteLine($"key: {((DictionaryEntry)temp).Key}-->value: {((DictionaryEntry)temp).Value}");
            }
            Console.WriteLine();


            int index = services.IndexOfKey(3);
            Console.WriteLine($"index of key 3 is {index}");
            Console.WriteLine();

            services.Insert(1,121,222228888);
            Console.WriteLine("after Insert");
            foreach (object temp in services)
            {
                Console.WriteLine($"key: {((DictionaryEntry)temp).Key}-->value: {((DictionaryEntry)temp).Value}");
            }

            bool IsFixedSize=services.IsFixedSize;
            bool IsReadOnly=services.IsReadOnly;
            bool IsSync=services.IsSynchronized;
            Console.WriteLine($"\nIs fixed size? {IsFixedSize}\nIs read only? {IsReadOnly}\nIs Synchronized? {IsSync}");
            Console.WriteLine();

            var key=services.Keys;
            Console.WriteLine("Keys:");
            foreach (object temp in key)
            {
                Console.WriteLine($"key: {temp}");
            }
            Console.WriteLine();

            var value = services.Values;
            Console.WriteLine("Values:");
            foreach (object temp in key)
            {
                Console.WriteLine($"key: {temp}");
            }

            object Sync=services.SyncRoot;
            
            services[1] = 123;
            Console.WriteLine("\nAfter adding by index");
            foreach (object temp in services)
            {
                Console.WriteLine($"key: {((DictionaryEntry)temp).Key}-->value: {((DictionaryEntry)temp).Value}");
            }
            Console.WriteLine();

            object Key = 3;
            Console.WriteLine("test of object index");
            if ((int)services[Key] == 777)
                Console.WriteLine("All good");
            else
                Console.WriteLine("Not good");

            services.RemoveAt(1);
            Console.WriteLine("\nremoving by index 1");
            foreach(object temp in services)
            {
                Console.WriteLine($"key: {((DictionaryEntry)temp).Key}-->value: {((DictionaryEntry)temp).Value}");
            }
            
            Services services1 = new Services();
            services1.Add("2", 123123);

            Services services2 = new Services();

            ToRuleCollection toRule = new ToRuleCollection();

            toRule.Add(services);
            toRule.Add(services2);
            toRule.Insert(1, services1);
            
            var temporary=toRule.Find(1);

            toRule.Clear();
            Console.WriteLine();
            Console.WriteLine("To rule clear");
            services.Clear();
            services1.Clear();
            services2.Clear();
            Console.WriteLine("\nServices clear");
        }
    }
}
