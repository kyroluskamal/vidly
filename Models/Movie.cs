using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using vidly.Controllers;
using WebGrease.Css.Ast.Selectors;

namespace vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public String Name { get; set; }
        [Required]
        [StringLength(255)]
        public String ReleaseDate { get; set; }
        [Required]
        [StringLength(255)]
        public String DateAdded { get; set; }
        [Required]
        public int numberInStock { get; set; }
        [Required]
        [StringLength(255)]
        public Genre genre { get; set; }
    }
}