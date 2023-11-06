using MVC.Models;

namespace MVC
{
    public class RolesInMemoryRepository : IRolesRepository
    {
        private List<Role> roles = new List<Role>();
        public List<Role> GetAllRoles()
        {
            return roles;
        }
        public void Add(Role role)
        {
            if (!roles.Contains(role))
            {
                roles.Add(role);
            }
        }

        public void Del(Role role)
        {
            roles.Remove(role);
        }
    }
}
