using System.Data;

namespace MVC.Models
{
    public class Product
    {
        private static int instanceCounter = 0;
        public int Id { get; }
        public string Name { get; }
        public string Author { get; }
        public int ReleaseYear { get; }
        public decimal Cost { get; }
        public string Description { get; }
        public string ImagePath { get; }
        public Product(string name, string author, decimal cost, string description, int releaseYear, string imagePath)
        {
            Id = instanceCounter;
            Name = name;
            Author = author;
            Cost = cost;
            Description = description;
            instanceCounter++;
            ReleaseYear = releaseYear;
            ImagePath = imagePath;
        }
    }
}
