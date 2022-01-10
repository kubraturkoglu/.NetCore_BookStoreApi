using System.Linq;
using WebApi.DBOperations;
using System;

namespace WebApi.Applications.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    { 
        private readonly BookStoreDbContext _dbContext;
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public DeleteAuthorCommand (BookStoreDbContext dbContext)
       
        {
            _dbContext = dbContext;

        }
        public void Handle()
        {
             var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId);
           
           //bu Id li author var mı
            if(author is null)
                throw new InvalidOperationException("Author is already deleted.");
            
            if(_dbContext.Books.Any(x => x.AuthorID == AuthorId))
             
              throw new InvalidOperationException("The Author has a book. You should first delete this book.");
          

            //sil gitsin 

           
            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
            
           
         
           
            
    
        

        }
       
    }
}