using MVC.Models;

namespace MVC
{
    public interface IRolesRepository
    {
        List<Roles> GetAllRoles();
        void Add(Roles role);
        void Del(Roles role);
    }
}