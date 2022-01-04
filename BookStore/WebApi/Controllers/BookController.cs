using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.DBOperations;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.CreateBook;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.UpDateBook;
using WebApi.BookOperations.DeleteBook;
using AutoMapper;
using FluentValidation;

namespace WebApi.Controllers
{

    [ApiController]
    [Route ("[controller]s")]
    public class BookController: ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

    public BookController(BookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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
       GetBooksQuery query = new GetBooksQuery(_context,_mapper);
       var result = query.Handle();
       return Ok(result);
     }
     [HttpGet("{id}")]
     public IActionResult GetById(int id)
     {
         BookDetailViewModel result;
         try
         {
             GetBookDetailQuery query= new GetBookDetailQuery(_context, _mapper);
             query.BookId = id;
             
             GetBookDetailQueryValidator validator= new GetBookDetailQueryValidator();
            validator.ValidateAndThrow(query);

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
        CreateBookCommand command = new CreateBookCommand(_context, _mapper);
        try
        {
            
            command.Model= newBook; 

            CreateBookCommandValidator validator= new CreateBookCommandValidator();
            validator.ValidateAndThrow(command);

             command.Handle();

            // if(!result.IsValid)
            //     foreach(var item in result.Errors)
            //         Console.WriteLine("Property"+ item.PropertyName +"-Error Message: " + item.ErrorMessage);
            // else
            //      command.Handle();

           


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

            UpDateBookCommandValidator validator= new UpDateBookCommandValidator();
            validator.ValidateAndThrow(command);

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
        try
        { 
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId = id;

            DeleteBookCommandValidatior validator = new DeleteBookCommandValidatior();
            validator.ValidateAndThrow(command);
            command.Handle();

        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
      

            return Ok();
    }


    }
}