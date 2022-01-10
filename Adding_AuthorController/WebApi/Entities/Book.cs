using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Book
    {
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        public int GenreID { get; set; }
        public int AuthorID { get; set; }

        public int Id { get; set; }
        public string Title { get; set; }
        
        public Genre Genre { get; set; }
        public Author Author { get; set; }
         
        public int PageCount { get; set; }
        public DateTime PublishDate{get;set;}

        }
      



    }

