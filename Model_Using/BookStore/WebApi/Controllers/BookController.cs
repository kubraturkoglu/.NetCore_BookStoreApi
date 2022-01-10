using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.DBOperations;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.CreateBook;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.UpDateBook;

namespace  WebApi.Controllers
{
    
    [ApiController]
    [Route ("[controller]s")]
    public class BookController: ControllerBase
    {
        private readonly BookStoreDbContext _context;

    public BookController(BookStoreDbContext context)
    {
        _context = context;
    }

    //  private static   List<Book> BookList = new List<Book> ()
    //  {
    //      new Book{

    //          Id=  1,
    //          Title="Lean StartUP",
    //          GenreID=1,  //Personal Growth
    //          PageCount=20,
    //          PublishDate = new  System.DateTime (2001,03,23)
    //      },
    //         new Book{

    //          Id=  2,
    //          Title="UPkjfldsş",
    //          GenreID=2, //Science Fiction
    //          PageCount=200,
    //          PublishDate = new  System.DateTime (2001,05,23)
    //      },
    //       new Book{

    //          Id=  3,
    //          Title="SSFDSSFS",
    //          GenreID=2, //Science Fiction
    //          PageCount=77,
    //          PublishDate = new  DateTime (2008,05,23)
    //      }
    //  };

    [HttpGet]
     public IActionResult GetBooks()
     {
       GetBooksQuery query = new GetBooksQuery(_context);
       var result = query.Handle();
       return Ok(result);
     }
     [HttpGet("{id}")]
     public IActionResult GetById(int id)
     {
         BookDetailViewModel result;
         try
         {
             GetBookDetailQuery query= new GetBookDetailQuery(_context);
             query.BookId = id;
             
             result= query.Handle();

         }
         catch(Exception ex)
         {
             return BadRequest(ex.Message);

         }
         return Ok( result);
      
     }
    //   [HttpGet]
    //  public Book Get([FromQuery] string id)
    //  {
    //      var book = BookList.Where(book  => book.Id == Convert.ToInt32(id) ).SingleOrDefault(); 
    //      return book;
    //  }
    [HttpPost]
    public IActionResult AddBook ([FromBody]CreateBookModel newBook)
    {
        CreateBookCommand command = new CreateBookCommand(_context);
        try
        {
            
            command.Model= newBook; 
            command.Handle();


        }
        catch(Exception ex)
        {
           return BadRequest(ex.Message);
        }
       
        return Ok();
    }

[HttpPut("{id}")]
    public IActionResult UpDateBook(int id,[FromBody] UpDateBookModel updatedBook)
    {
        try
        {
            UpDateBookCommand command = new UpDateBookCommand(_context);
            command.BookId = id;
            command.Model = updatedBook;
            command.Handle();
       

        }
        catch(Exception ex)
        {
           return BadRequest(ex.Message);
        }
        
     
        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        var book = _context.Books.SingleOrDefault(x => x.Id == id);
        if (book is null)
            return BadRequest();

        _context.Books.Remove(book);
        _context.SaveChanges();
            return Ok();
    }


    }
}