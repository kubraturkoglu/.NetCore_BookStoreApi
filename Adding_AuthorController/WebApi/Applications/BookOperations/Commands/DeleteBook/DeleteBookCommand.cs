using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Common;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebApi.Applications.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommand
    { 
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public DeleteBookCommand (BookStoreDbContext dbContext)
       
        {
            _dbContext = dbContext;

        }
        public void Handle()
        {
             var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);

            if(book is null) 
                
                throw new InvalidOperationException("Book is already deleted.");
         
        
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();


        }
       
    }
}