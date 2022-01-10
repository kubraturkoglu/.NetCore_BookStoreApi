using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using WebApi.Entities;

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
                context.Authors.AddRange(
                    new Author 
                    {
                        Name = "Paula",
                        Surname =" Coelho",
                        BirthDate = new  System.DateTime (2001,03,23)
                    },
                       new Author 
                    {
                        Name = "Agatha  ",
                        Surname =" Christie",
                        BirthDate = new  System.DateTime (1890,09,15)
                    },
                       new Author 
                    {
                        Name = "Barbara",
                        Surname ="Cartland",
                        BirthDate = new  System.DateTime (1947,08,24)

                    }

                );
                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"
                    },
                     new Genre
                    {
                        Name = "Science Fiction"
                    },
                     new Genre
                    {
                        Name = "Romance"
                    }
                );
                context.Books.AddRange(
                      new Book
                      {

                       // Id=  1,
                        Title="Lean StartUP",
                        GenreID=1,  //Personal Growth
                        AuthorID =1,
                        PageCount=20,
                        PublishDate = new  System.DateTime (2001,03,23),
                        
                      },
                      new Book
                      {
                        // Id=  2,
                        Title="ABC2",
                        GenreID=2, //Science Fiction
                        AuthorID= 2,
                        PageCount=200,
                        PublishDate = new  System.DateTime (2001,05,23)
                      },
                      new Book
                      {
                       //  Id=  3,
                        Title="BCD",
                        GenreID=3, //Science Fiction
                        AuthorID = 3,
                        PageCount=77,
                        PublishDate = new  DateTime (2008,05,23)
                    }
                );
                context.SaveChanges();
            }
        }
    }
}