using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.AuthorOperations.Commands.CreateAuthor;
using WebApi.Applications.AuthorOperations.Commands.DeleteAuthor;
using WebApi.Applications.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Applications.AuthorOperations.Commands.UpDateAuthor;
using WebApi.Applications.AuthorOperations.Queries.GetAuthor;
using WebApi.Applications.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Applications.GenreOperations.Commands.CreateAuthor;
using WebApi.DBOperations;

namespace WebApi.Controllers
{

    [ApiController]
    [Route ("[controller]s")]
    public class AuthorController: ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

    public AuthorController(BookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult GetAuthors()
    {
        GetAuthorQuery query = new GetAuthorQuery(_context , _mapper);
        var obj = query.Handle();
        return Ok(obj);
    }
        [HttpGet("id")]
    public ActionResult GetAuthorDetail(int id)
    {
        GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context , _mapper);
        query.AuthorId = id;
        GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
        validator.ValidateAndThrow(query);

        var obj = query.Handle();
        return Ok(obj);
    }
    [HttpPost]
    public IActionResult AddAuthor ([FromBody]CreateAuthorModel newAuthor)
    {
        CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
  
        command.Model= newAuthor; 

        CreateAuthorCommandValidator validator= new CreateAuthorCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();   

        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult UpdateAuthor(int id,[FromBody] UpdateAuthorModel updatedAuthor)
    {
      
        UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
        command.AuthorId = id;    
        command.Model = updatedAuthor;

        UpdateAuthorCommandValidator validator= new UpdateAuthorCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();    
       
        return Ok();
    }
     [HttpDelete("{id}")]
    public IActionResult DeleteAuthor(int id)
    {
     
        DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
        command.AuthorId = id;

        DeleteAuthorCommandValidatior validator = new DeleteAuthorCommandValidatior();
        validator.ValidateAndThrow(command);
        command.Handle();

        return Ok();
    }
    

 }
}