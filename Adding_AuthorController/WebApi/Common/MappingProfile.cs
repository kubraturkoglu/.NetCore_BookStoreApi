using AutoMapper;
using WebApi.Applications.AuthorOperations.Queries.GetAuthor;
using WebApi.Applications.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Applications.BookOperations.Queries.GetBookDetail;
using WebApi.Applications.BookOperations.Queries.GetBooks;
using WebApi.Applications.GenreOperations.Commands.CreateAuthor;
using WebApi.Applications.GenreOperations.Queries.GetGenreDetail;
using WebApi.Applications.GenreOperations.Queries.GetGenres;
using WebApi.Entities;
using static WebApi.Applications.BookOperations.Commands.CreateBook.CreateBookCommand;

namespace WebApi.Common
{
    public class MappingProfile: Profile
    { 
        public MappingProfile()
        {
            CreateMap<CreateBookModel,Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest=> dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest=> dest.Author, opt => opt.MapFrom(src => src.Author.Name+src.Author.Surname));
            CreateMap<Book, BooksViewModel>().ForMember(dest=> dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest=> dest.Author, opt => opt.MapFrom(src => src.Author.Name+src.Author.Surname));

      
           
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenresDetailViewModel>();
           
            CreateMap<Author, AuthorViewModel>();
            CreateMap<Author, AuthorDetailViewModel>();
            CreateMap<CreateAuthorModel, Author>();
            
        }

    }


}