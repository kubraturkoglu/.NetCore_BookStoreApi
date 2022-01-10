using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange(
                      new Book
                      {

                       // Id=  1,
                        Title="Lean StartUP",
                        GenreID=1,  //Personal Growth
                        PageCount=20,
                        PublishDate = new  System.DateTime (2001,03,23)
                      },
                      new Book
                      {
                        // Id=  2,
                        Title="ABC2",
                        GenreID=2, //Science Fiction
                        PageCount=200,
                        PublishDate = new  System.DateTime (2001,05,23)
                      },
                      new Book
                      {
                       //  Id=  3,
                        Title="BCD",
                        GenreID=2, //Science Fiction
                        PageCount=77,
                        PublishDate = new  DateTime (2008,05,23)
                    }
                );
                context.SaveChanges();
            }
        }
    }
}