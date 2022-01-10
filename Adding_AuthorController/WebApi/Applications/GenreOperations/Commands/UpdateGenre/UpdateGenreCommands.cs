
using System;
using System.Linq;
using WebApi.Applications.BookOperations.Commands.UpDateBook;
using WebApi.DBOperations;

namespace WebApi.Applications.GenreOperations.Commands.UpateGenre
{
    public class UpdateGenreCommands
    {
         private readonly BookStoreDbContext _dbContext;
         public UpdateGenreModel Model{get; set; }
        public int GenreId { get; set; }
        
        public UpdateGenreCommands(BookStoreDbContext dbContext)
        
        {
            _dbContext = dbContext;

        }
        public void  Handle()
        {

           var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == GenreId);
           if(genre is null)
                 throw new InvalidOperationException("The Book path is not found.");
            if(_dbContext.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId))
                throw new InvalidOperationException(" Same Book Name is already exist. ");

            genre.Name = string.IsNullOrEmpty(Model.Name.Trim ()) == default ? Model.Name : genre.Name;
            genre.IsActive = Model.IsActive;
            _dbContext.SaveChanges();
        }
        public class UpdateGenreModel
        {
            public string Name { get; set; }
            public bool IsActive { get; set; } = true;
        }
    }
}