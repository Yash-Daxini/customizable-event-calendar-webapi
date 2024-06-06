﻿using AutoMapper;
using Core.Entities;
using Infrastructure;
using Infrastructure.Profiles;
using Infrastructure.Repositories;

namespace UnitTests.Infrastructure.Repositories.SharedCalendarRepositoryTests;

public class UpdateSharedCalendar
{
    private DbContextEventCalendar _dbContext;

    private readonly IMapper _mapper;
    public UpdateSharedCalendar()
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
    }

    [Fact]
    public async Task Should_UpdateSharedCalendar_When_SharedCalendarAvailableWithId()
    {
        _dbContext = await new SharedCalendarRepositoryDBContext().GetDatabaseContext();

        SharedCalendarRepository sharedCalendarRepository = new(_dbContext, _mapper);

        _dbContext.ChangeTracker.Clear();   

        SharedCalendar sharedCalendar = new()
        {
            Id = 1,
            Sender = new()
            {
                Id = 1,
                Name = "a",
                Email = "a",
                Password = "a",
            },
            Receiver = new()
            {
                Id = 2,
                Name = "b",
                Email = "b",
                Password = "b",
            },
            FromDate = new DateOnly(2024, 6, 7),
            ToDate = new DateOnly(2024, 6, 7)
        };

        await sharedCalendarRepository.Update(sharedCalendar);

        SharedCalendar? updatedSharedCalendar = await sharedCalendarRepository.GetSharedCalendarById(1);

        Assert.Equivalent(sharedCalendar, updatedSharedCalendar);
    }
}
