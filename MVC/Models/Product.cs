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

        [Required(ErrorMessage ="Введите автора продукта")]
        public string Author { get; set; }

        [Required(ErrorMessage ="Не указан год релиза")]
        [Range(2000,2023,ErrorMessage ="Год релиза должен быть в пределах от 2000х до 2023гг")]
        public int ReleaseYear { get; set; }

        [Required(ErrorMessage ="Не указана цена товара")]
        [Range(1,999999,ErrorMessage ="Цена товара должна быть в диапазоне от 1 до 999 999 р.")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage ="Добавте описание к товару")]
        public string Description { get; set; }

        [Required(ErrorMessage ="Не указан путь изображения товара")]
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
