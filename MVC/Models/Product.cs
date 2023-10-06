using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.Metrics;

namespace MVC.Models
{
    public class Product
    {
        private static int id=0;
        public int Id { get; set; }

        [Required(ErrorMessage ="Не указано наименование товара")]
        [StringLength(70,MinimumLength =3,ErrorMessage ="Наименование должно содержать от 3 до 70 символов")]
        public string Name { get; set; }

      
        public string Author { get; set; }
        public int ReleaseYear { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public Product(string name, string author, int releaseYear, decimal cost, string description, string imagePath)
        {
            Id = id;
            Name = name;
            Author = author;
            ReleaseYear = releaseYear;
            Cost = cost;
            Description = description;
            ImagePath = imagePath;
            id++;
        }

    }
}
