
using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Applications.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommands
    {
        private readonly BookStoreDbContext _dbContext;
        
        public int GenreId { get; set; }

        public DeleteGenreCommands(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
    {
        var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == GenreId);
        if (genre is null)
            throw new InvalidOperationException(" Book type is not found !");

         _dbContext.Genres.Remove(genre);
         _dbContext.SaveChanges();
    }
    }
    
}