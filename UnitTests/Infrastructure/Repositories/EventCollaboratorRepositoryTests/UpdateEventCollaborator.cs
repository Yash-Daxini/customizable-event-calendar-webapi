﻿using AutoMapper;
using Core.Entities;
using Infrastructure.Repositories;
using Infrastructure;
using NSubstitute;
using Infrastructure.DataModels;

namespace UnitTests.Infrastructure.Repositories.EventCollaboratorRepositoryTests;

public class UpdateEventCollaborator : IClassFixture<AutoMapperFixture>
{
    private DbContextEventCalendar _dbContext;
    private readonly IMapper _mapper;

    public UpdateEventCollaborator(AutoMapperFixture autoMapperFixture)
    {
        _mapper = autoMapperFixture.Mapper;
    }

    [Fact]
    public async Task Should_UpdateEventCollaborator_When_EventCollaboratorAvailableWithGivenId()
    {
        _dbContext = await new EventCollaboratorRepositoryDBContext().GetDatabaseContext();

        EventCollaboratorRepository eventCollaboratorRepository = new(_dbContext, _mapper);

        EventCollaborator eventCollaborator = new()
        {
            Id = 1,
            EventCollaboratorRole = Core.Entities.Enums.EventCollaboratorRole.Organizer,
            ConfirmationStatus = Core.Entities.Enums.ConfirmationStatus.Accept,
            EventDate = new DateOnly(),
            EventId = 1,
            User = new()
            {
                Id = 1,
                Name = "a",
                Email = "a",
                Password = "a",
            },
            ProposedDuration = null
        };

        _dbContext.ChangeTracker.Clear();

        await eventCollaboratorRepository.Update(eventCollaborator);

        EventCollaborator? updatedEventCollaborator = await eventCollaboratorRepository.GetEventCollaboratorById(1);

        Assert.Equivalent(eventCollaborator,updatedEventCollaborator);
    }
}
