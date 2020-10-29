using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using vidly.Controllers;
using WebGrease.Css.Ast.Selectors;

namespace vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Please Enter Movie name")]  [StringLength(255)]
        public String Name { get; set; }
        
        [Required(ErrorMessage = "Please Enter release Date")]  [Display(Name = "Released Date")]
        public DateTime? ReleaseDate { get; set; }
        
        [Required(ErrorMessage = "Please Enter Added date")]  [Display(Name ="Date Added")]
        public DateTime? DateAdded { get; set; }
        
        [Required(ErrorMessage ="Please enter number in stock")]  
        [Display(Name = "Number in Stock")]
        [Range(1,2, ErrorMessage ="Number Should be between 1 and  20")]
        public int numberInStock { get; set; }
        
        [StringLength(255)]
        public Genre Genre { get; set; }
        
        [Required(ErrorMessage = "Please Choose Movie Genre")]  [Display(Name = "Genre")]
        public int GenreId { get; set; }
    }
}