using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Applications.AuthorOperations.Queries.GetAuthor
{
    public class GetAuthorQuery
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        public GetAuthorQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorViewModel> Handle ()
        {
            var authors = _context.Authors.Where(x => x.IsActive).OrderBy(x =>x.Id); //Is Active diye bir kolon yarattık sadece actif olanlar gozuksun.
            List<AuthorViewModel> returnObj = _mapper.Map<List<AuthorViewModel>>(authors); //geri dönüs View Moedli
            //author da sınıfları bırbırıne donusturdugumuz kısım.
            return returnObj; //  Yukarıda birbiri arasında etkileşim kurdugumuz kısım.
        }
    }
    public class AuthorViewModel
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Surname { get; set; }
       public DateTime BirthDate { get; set; }

    }
}