using System.Linq;
using WebApi.DBOperations;
using System;

namespace WebApi.Applications.AuthorOperations.Commands.UpDateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int AuthorId { get; set; }
        public  UpdateAuthorModel Model { get; set; }
        public UpdateAuthorCommand(BookStoreDbContext dbContext)
        
        {
            _dbContext = dbContext;

        }
        public void  Handle()
        { 
             var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId);
           
            if(author is null)
                throw new InvalidOperationException("There is not a Book to Update  ");

            if(_dbContext.Authors.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != AuthorId))
                throw new InvalidOperationException(" Same Book Name is already exist. ");
       
         
            author.Name = Model.Name.Trim() == default?  author.Name:Model.Name;
            author.Surname = Model.Surname.Trim() == default?  author.Surname: Model.Surname;
            

            _dbContext.SaveChanges();
              
            
        }
    }


    public class UpdateAuthorModel 
    {
        public string Name { get; set; }
          
        public string Surname { get; set; }
       
        
    }
}