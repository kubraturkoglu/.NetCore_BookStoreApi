using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
namespace WebApi
{
    public class Book
    {
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreID { get; set; }
        public int PageCount { get; set; }
       public DateTime PublishDate{get;set;}

        }
      



    }

