using System.Data;
using System.Diagnostics.Metrics;

namespace MVC.Models
{
    public class Product
    {
        private static int id=0;

        public int Id { get; set; }
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
