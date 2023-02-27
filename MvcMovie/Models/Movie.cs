using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Display(Name = "Título"), StringLength(60, MinimumLength = 3)]
        public string? Title { get; set; }

        [Display(Name = "Data de Lançamento"), DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Gênero"), RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), Required, StringLength(30)]
        public string? Genre { get; set; }

        [Display(Name = "Preço"), Range(1, 100), DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Display(Name = "Avaliação"), RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), StringLength(5)]
        public string? Rating { get; set; }
    }
}