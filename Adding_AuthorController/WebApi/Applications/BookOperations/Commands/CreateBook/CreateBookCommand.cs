using System.Linq;
using WebApi.DBOperations;
using System;
using AutoMapper;
using WebApi.Entities;

namespace WebApi.Applications.BookOperations.Commands.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model{ get; set;}
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

      

        public CreateBookCommand(BookStoreDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
             var book = _dbContext.Books.SingleOrDefault(x => x.Title== Model.Title);

            if(book is not null) 
                
                throw new InvalidOperationException("Book is already exist.");
               
                book = _mapper.Map<Book>(Model);

              //  book = new Book();
                // book.Title = Model.Title;
                // book.PublishDate= Model.PublishDate;
                // book.PageCount = Model.PageCount;
                // book.GenreID= Model.GenreId;


            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();


        }
        public class CreateBookModel 
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int AuthorId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}