using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Common;
using Microsoft.EntityFrameworkCore;
using System;
using AutoMapper;

namespace WebApi.Applications.BookOperations.Queries.GetBookDetail

{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get ; set ; }
        public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
          _dbContext = dbContext;
          _mapper = mapper;
        }
        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Include(x => x.Genre).Where(book  =>book.Id== BookId ).SingleOrDefault(); 
            book =_dbContext.Books.Include(x => x.Author).Where(book  =>book.Id== BookId ).SingleOrDefault();
            if(book is null)
            {
                throw new InvalidOperationException("The book is not exist.");
            }
            BookDetailViewModel vn = _mapper.Map<BookDetailViewModel>(book);
            //BookDetailViewModel vn = new BookDetailViewModel();
            // vn.Title = book.Title;
            // vn.PageCount= book.PageCount;
            // vn.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy");
            // vn.Genre = ((GenreEnum)book.GenreID).ToString();

            return vn;
        }
    }

    public class BookDetailViewModel
    {
         public string Title { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}