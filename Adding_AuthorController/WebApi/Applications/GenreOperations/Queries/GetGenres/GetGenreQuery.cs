
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Applications.GenreOperations.Queries.GetGenres
{
    public class GetGenreQuery
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        public GetGenreQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GenresViewModel> Handle ()
        {
            var genres = _context.Genres.Where(x => x.IsActive).OrderBy(x =>x.Id); //Is Active diye bir kolon yarattık sadece actif olanlar gozuksun.
            List<GenresViewModel> returnObj = _mapper.Map<List<GenresViewModel>>(genres);
            return returnObj;
        }
    }
    public class GenresViewModel
    {
       public int Id { get; set; }
       public string Name { get; set; }

    }
}