
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.GenreOperations.Commands.CreateGenre;
using WebApi.Applications.GenreOperations.Commands.DeleteGenre;
using WebApi.Applications.GenreOperations.Commands.UpateGenre;
using WebApi.Applications.GenreOperations.Commands.UpdateGenre;
using WebApi.Applications.GenreOperations.Queries.GetGenreDetail;
using WebApi.Applications.GenreOperations.Queries.GetGenres;
using WebApi.DBOperations;
using static WebApi.Applications.GenreOperations.Commands.UpateGenre.UpdateGenreCommands;

namespace WebApi.Controllers
{

    [ApiController]
    [Route ("[controller]s")]
    public class GenresController: ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

    public GenresController(BookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult GetGenres()
    {
        GetGenreQuery query = new GetGenreQuery(_context , _mapper);
        var obj = query.Handle();
        return Ok(obj);
    }

       [HttpGet("id")]
    public ActionResult GetGenreDetail(int id)
    {
        GetGenreDetailQuery query = new GetGenreDetailQuery(_context , _mapper);
        query.GenreId = id;
        GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
        validator.ValidateAndThrow(query);

        var obj = query.Handle();
        return Ok(obj);
    }
    [HttpPost]
    public IActionResult AddGenre ([FromBody]CreateGenreModel newGenre)
    {
        CreateGenreCommand command = new CreateGenreCommand(_context);
  
        command.Model= newGenre; 

        CreateGenreCommandValidator validator= new CreateGenreCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();   

        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult UpDateGenre(int id,[FromBody] UpdateGenreModel updatedGenre)
    {
      
        UpdateGenreCommands command = new UpdateGenreCommands(_context);
        command.GenreId = id;    
        command.Model = updatedGenre;

        UpdateGenreCommandValidator validator= new UpdateGenreCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();    
       
        return Ok();
    }
     [HttpDelete("{id}")]
    public IActionResult DeleteGenre(int id)
    {
     
        DeleteGenreCommands command = new DeleteGenreCommands(_context);
        command.GenreId = id;

        DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
        validator.ValidateAndThrow(command);
        command.Handle();

        return Ok();
    }
    }
}

