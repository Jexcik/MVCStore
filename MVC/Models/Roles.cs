using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Roles
    {
        [Required(ErrorMessage = "Введите название роли")]
        public string Name { get; set; }
        public Roles() { }
        public Roles(string name)
        {
            Name = name;
        }
    }
}
