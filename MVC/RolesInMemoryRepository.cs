using MVC.Models;

namespace MVC
{
    public class RolesInMemoryRepository : IRolesRepository
    {
        private List<Roles> roles = new List<Roles>();
        public List<Roles> GetAllRoles()
        {
            return roles;
        }
        public void Add(Roles role)
        {
            if (!roles.Contains(role))
            {
                roles.Add(role);
            }
        }

        public void Del(Roles role)
        {
            roles.Remove(role);
        }
    }
}
