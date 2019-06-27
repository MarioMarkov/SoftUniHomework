using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics
{
    public class CustomList<T> : ICustomList<T>,IEnumerable<T>
        where T: IComparable<T>
    {
        private const int InitialCapasity = 4;

        public CustomList()
        {
            this.Array = new T[InitialCapasity];
            this.Count = 0;
        }

        public T[] Array { get; set; }

        public int Count { get; private set; }

        public void Swap(int index1, int index2)
        {
            T temp = this.Array[index1];
            this.Array[index1] = this.Array[index2];
            this.Array[index2] = temp;
        }

        public void Add(T element)
        {
            if (this.Array.Length == this.Count)
            {
                Resize();
            }
            this.Array[this.Count++] = element;
            
        }

       

        public T Remove(int index)
        {
            if (index<0  || index >= this.Count)
            {
                throw new InvalidOperationException();
            }
            T element = this.Array[index];
            this.Array[index] = default(T);
            this.Count--;
            for (int i = index; i < this.Count; i++)
            {
               
                this.Array[i] = this.Array[i + 1];
            }
            if (this.Array.Length != this.Count)
            {
                this.Array[this.Count] = default(T);
            }
            return element;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Array[i].Equals(element) )
                {
                    return true;
                }
            }
            return false;
        }

        public int CountGreaterThan(T element)
        {
            int counter = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Array[i].CompareTo(element)>0)
                {
                    counter++;
                }
            }
            return counter;
        }

        public T Max()
        {
            if (this.Count==0)
            {
                throw new InvalidOperationException();
            }
            T maxValue = this.Array[0];
            for (int i = 1; i < this.Count; i++)
            {
                if (this.Array[i].CompareTo(maxValue)>0)
                {
                    maxValue = this.Array[i];
                }
            }
            return maxValue;
        }

        public T Min()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
            T minValue = this.Array[0];
            for (int i = 1; i < this.Count; i++)
            {
                if (this.Array[i].CompareTo(minValue) < 0)
                {
                    minValue = this.Array[i];
                }
            }
            return minValue;
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in this.Array)
            {
                builder.AppendLine(item.ToString());
                
            }
            return builder.ToString().TrimEnd();
        }
        private void Resize()
        {
            T[] temp = new T[this.Array.Length*2];
            for (int i = 0; i < this.Array.Length; i++)
            {
                temp[i] = this.Array[i];
            }
            this.Array = temp;
        }

        public void Sort()
        {
            for (int i = 0; i < this.Count; i++)
            {
                for (int j = i+1; j < this.Count; j++)
                {
                    if (this.Array[i].CompareTo(this.Array[j])>0)
                    {
                        T temp = this.Array[i];
                        this.Array[i] = this.Array[j];
                        this.Array[j] = temp;
                    }
                }
            }
            
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.Array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
