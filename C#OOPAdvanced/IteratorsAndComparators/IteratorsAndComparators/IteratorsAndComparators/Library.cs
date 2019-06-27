﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library: IEnumerable<Book>
    {
        private readonly List<Book> books;
        
        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }
        public void Sort()
        {
            this.books.Sort(new BookComparator());
        }
        
        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < this.books.Count; i++)
            {
                yield return this.books[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        
        //private class LibraryIterator : IEnumerator<Book>
        //{
        //    private readonly List<Book> books;
        //    private int currentIndex;

        //    public LibraryIterator(List<Book> books)
        //    {
        //        this.Reset();
        //        this.books = books;
        //    }

        //    public Book Current => this.books[currentIndex];

        //    object IEnumerator.Current => this.Current;

        //    public void Dispose(){ }
        //    public bool MoveNext()=> ++currentIndex < this.books.Count;
        //    public void Reset() => this.currentIndex = -1;
            
        //}
    }

    
}
