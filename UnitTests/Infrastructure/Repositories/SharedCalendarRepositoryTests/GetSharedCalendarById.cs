﻿using AutoMapper;
using Core.Entities;
using Infrastructure.Repositories;
using Infrastructure;

namespace UnitTests.Infrastructure.Repositories.SharedCalendarRepositoryTests;

public class GetSharedCalendarById : IClassFixture<AutoMapperFixture>
{
    private DbContextEventCalendar _dbContext;
    private readonly IMapper _mapper;

    public GetSharedCalendarById(AutoMapperFixture autoMapperFixture)
    {
        _mapper = autoMapperFixture.Mapper;
    }

    [Fact]
    public async Task Should_ReturnSharedCalendar_When_SharedCalendarAvailableWithGivenId()
    {
        _dbContext = await new SharedCalendarRepositoryDBContext().GetDatabaseContext();

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

        SharedCalendarRepository sharedCalendarRepository = new(_dbContext, _mapper);

        SharedCalendar? sharedCalendarById = await sharedCalendarRepository.GetSharedCalendarById(1);

        Assert.Equivalent(sharedCalendar, sharedCalendarById);
    }

    [Fact]
    public async Task Should_ReturnNull_When_SharedCalendarNotAvailableWithGivenId()
    {
        _dbContext = await new SharedCalendarRepositoryDBContext().GetDatabaseContext();

        SharedCalendar sharedCalendar = new()
        {
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

        SharedCalendarRepository sharedCalendarRepository = new(_dbContext, _mapper);

        SharedCalendar? sharedCalendarById = await sharedCalendarRepository.GetSharedCalendarById(2);

        Assert.Null(sharedCalendarById);
    }
}
