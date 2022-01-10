using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Applications.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        public int AuthorId { get; set; }
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        public GetAuthorDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handle ()
        {
            var author= _context.Authors.SingleOrDefault(x => x.IsActive && x.Id == AuthorId); //Is Active diye bir kolon yarattık sadece actif olanlar gozuksun.
            
            if(author is null)
            throw new InvalidOperationException(" Author is not exist ");
            return _mapper.Map<AuthorDetailViewModel>(author);
        }
    }
    public class AuthorDetailViewModel
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Surname { get; set; }
       public DateTime BirthDate { get; set; }
    }
}