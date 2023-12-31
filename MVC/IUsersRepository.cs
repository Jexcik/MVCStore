﻿using MVC.Areas.Admin.Models;
using MVC.Models;

namespace MVC
{
    public interface IUsersRepository
    {
        List<User> GetAll();
        User TryGetById(Guid userId);
        User TryGetByName(string name);
        void Del(Guid userId);
        void Add(User user);
        void Edit(EditUser user, Guid userId);
        void ChangePassword(Guid userId, string password);
        void ChangeAccess(Guid userId, string roleName);
    }
}
