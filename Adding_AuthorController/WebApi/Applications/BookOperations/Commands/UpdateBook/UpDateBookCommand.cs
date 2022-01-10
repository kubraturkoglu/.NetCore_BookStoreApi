using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Common;
using System;

namespace WebApi.Applications.BookOperations.Commands.UpDateBook
{
    public class UpDateBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public  UpDateBookModel Model { get; set; }
        public UpDateBookCommand(BookStoreDbContext dbContext)
        
        {
            _dbContext = dbContext;

        }
        public void  Handle()
        { 
             var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
           
              if(book is null)
                throw new InvalidOperationException("There is not a Book to Update  ");

        book.GenreID = Model.GenreId != default ?  Model.GenreId : book.GenreID;
        book.Title = Model.Title != default? Model.Title : Model.Title;

        _dbContext.SaveChanges();
              
            
        }
    }


    public class UpDateBookModel 
    {
        public string Title { get; set; }
     
        public int GenreId { get; set; }
    }
}