using MVC.Areas.Admin.Models;
using MVC.Models;

namespace MVC
{
    public class UsersInMemoryRepository : IUsersRepository
    {
        private readonly List<User> users = new List<User>()
    {
        new User("evgen@evgen.ru", "12345678", "Евгений", "Егоров", "+79150251037"),
        new User("Jexcik@Egorov.ru", "12345678", "Евгений", "Петров", "+79164875124")
        };

        public List<User> GetAll()
        {
            return users;
        }

        public User TryGetById(Guid usertId)
        {
            return users.FirstOrDefault(user => user.Id == usertId);
        }

        public User TryGetByName(string name)
        {
            return users.FirstOrDefault(user => user.Name == name);
        }

        public void Del(Guid usertId)
        {
            var user = TryGetById(usertId);
            users.Remove(user);
        }

        public void Add(User user)
        {
            users.Add(user);
        }

        public void Edit(EditUser user, Guid userId)
        {
            var currentUser = TryGetById(userId);
            currentUser.Name = user.UserName;
            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;
            currentUser.Phone = user.Phone;
        }

        public void ChangePassword(Guid userId, string password)
        {
            var currentUser = TryGetById(userId);
            currentUser.Password = password;
        }

        public void ChangeAccess(Guid userId, string roleName)
        {
            var currentUser = TryGetById(userId);
            currentUser.Role.Name = roleName;
        }
    }
}
