using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTesting
{
   public class Database
    {
        private const int Capasity = 16;
        private int[] data;
        private int freeIndex;
        public Database()
        {
            this.freeIndex = 0;
            this.data = new int[Capasity]; 
        }
        public Database(params int[] values):this()
        {
            this.freeIndex = values.Length-1;
            this.SetValues(values);
        }
        public void Add(int value)
        {
            //TODO Test if index value is 15
            if (this.freeIndex< this.data.Length)
            {
                this.data[this.freeIndex] = value;
                this.freeIndex++;
                return;
            }
            throw new InvalidOperationException("Database is full");
        }
        public void Remove()
        {
            if (this.freeIndex ==0)
            {
                throw new InvalidOperationException("Database is empty");
            }
            this.data[this.freeIndex - 1] = 0;
            this.freeIndex--;
        }
        public int[] Fetch()
        {
            return data.Take(this.freeIndex).ToArray();
        }


        private void SetValues(int[] values)
        {
            if (values.Length> 16)
            {
                throw new InvalidOperationException("Parameter is too long");
            }
            for (int i = 0; i < values.Length; i++)
            {
                this.data[i] = values[i];
            }
        }
    }
}
