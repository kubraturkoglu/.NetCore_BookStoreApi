
using System;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Applications.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public  CreateGenreModel Model { get; set; }
        private readonly BookStoreDbContext _context;
        public CreateGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault( x => x.Name ==Model.Name);
            if (genre  is not null)
            throw new InvalidOperationException("The Book is already exist !");

            genre = new Genre();
            genre.Name = Model.Name;
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

    }
     public class CreateGenreModel 
     {
         public string Name { get; set; }

     }
}