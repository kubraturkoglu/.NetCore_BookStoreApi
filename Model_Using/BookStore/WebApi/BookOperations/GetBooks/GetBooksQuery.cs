using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Common;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public GetBooksQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public List<BooksViewModel>  Handle()
        {
             var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>(); 
             List<BooksViewModel> vn = new List<BooksViewModel>();
             foreach(var item in bookList)
             {
                 vn.Add(new BooksViewModel()
                 {
                     
                    Title =item.Title,
                    Genre = ((GenreEnum)item.GenreID).ToString(),
                    PublishDate =item.PublishDate.Date.ToString("dd/MM/yyy"),
                    PageCount= item.PageCount
                     


                 });

             }
             return vn;
        }
    }

    public class BooksViewModel 
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}