using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Applications.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public int GenreId { get; set; }
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        public GetGenreDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenresDetailViewModel Handle ()
        {
            var genre= _context.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId); //Is Active diye bir kolon yarattık sadece actif olanlar gozuksun.
            
            if(genre is null)
            throw new InvalidOperationException(" Book is not exist ");
            return _mapper.Map<GenresDetailViewModel>(genre);
        }
    }
    public class GenresDetailViewModel
    { 
       public int Id { get; set; }
       public string Name { get; set; }

    }
}