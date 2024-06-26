﻿using Core.Entities;

namespace Core.Interfaces.IServices;

public interface IUserService
{
    public Task<User> GetUserById(int userId);

    public Task<int> AddUser(User userModel);

    public Task UpdateUser(User userModel);

    public Task DeleteUser(int userId);

    public Task<User?> AuthenticateUser(User user);
}
