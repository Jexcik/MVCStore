using MVC.Models;

namespace MVC
{
    public interface IRolesRepository
    {
        List<Role> GetAllRoles();
        void Add(Role role);
        void Del(Role role);
    }
}