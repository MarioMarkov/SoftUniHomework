using System.Linq;

namespace BookShop
{
    using Data;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
               Console.WriteLine(RemoveBooks(db));
                //Console.WriteLine(IncreasePrices(db));
            }
            
        }

        public static  int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Copies < 4200);
            context.Books.RemoveRange(books);
           

            return context.SaveChanges();
        }
    }
}
