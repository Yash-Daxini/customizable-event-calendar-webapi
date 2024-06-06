﻿using AutoMapper;
using Core.Entities;
using Infrastructure.Repositories;
using Infrastructure;
using Infrastructure.Profiles;

namespace UnitTests.Infrastructure.Repositories.UserRepositoryTests;

public class DeleteUser
{
    private DbContextEventCalendar _dbContext;

    private readonly IMapper _mapper;

    private readonly List<User> _users;

    public DeleteUser()
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new EventProfile());
            mc.AddProfile(new SharedCalendarProfile());
            mc.AddProfile(new EventCollaboratorProfile());
            mc.AddProfile(new UserProfile());
        });
        IMapper mapper = mappingConfig.CreateMapper();
        _mapper = mapper;
        _users = [ new(){

            Id = 1,
            Name = "a",
            Password = "a",
            Email = "a",
        }];
    }

    [Fact]
    public async Task Should_DeleteUser_When_UserWithIdAvailable()
    {
        _dbContext = await new UserRepositoryDBContext().GetDatabaseContext();

        User user = new()
        {
            Id = 1,
            Name = "a",
            Password = "a",
            Email = "a",
        };

        _dbContext.ChangeTracker.Clear();

        UserRepository userRepository = new(_dbContext, _mapper);

        await userRepository.Delete(user);

        User? deletedUser = await userRepository.GetUserById(1);

        Assert.Null(deletedUser);
    }
}