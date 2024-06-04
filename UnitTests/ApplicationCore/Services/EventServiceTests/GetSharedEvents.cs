﻿using Core.Entities;
using Core.Interfaces.IRepositories;
using Core.Interfaces.IServices;
using Core.Services;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace UnitTests.ApplicationCore.Services.EventServiceTests;

public class GetSharedEvents
{
    private readonly IEventRepository _eventRepository;

    private readonly IRecurrenceService _recurrenceService;
    private readonly IEventCollaboratorService _eventCollaboratorService;
    private readonly IOverlappingEventService _overlappingEventService;
    private readonly ISharedCalendarService _sharedCalendarService;
    private readonly IEventService _eventService;
    private readonly List<Event> _events;

    public GetSharedEvents()
    {
        _eventRepository = Substitute.For<IEventRepository>();
        _recurrenceService = Substitute.For<IRecurrenceService>();
        _eventCollaboratorService = Substitute.For<IEventCollaboratorService>();
        _overlappingEventService = Substitute.For<IOverlappingEventService>();
        _sharedCalendarService = Substitute.For<ISharedCalendarService>();
        _eventService = new EventService(_eventRepository, _recurrenceService, _eventCollaboratorService, _overlappingEventService, _sharedCalendarService);
        _events =
        [
            new()
    {
        Id = 2205,
        Title = "event",
        Location = "event",
        Description = "event",
        Duration = new Duration()
        {
            StartHour = 1,
            EndHour = 2
        },
        RecurrencePattern = new RecurrencePattern()
        {
            StartDate = new DateOnly(2024, 5, 31),
            EndDate = new DateOnly(2024, 8, 25),
            Frequency = Core.Entities.Enums.Frequency.Weekly,
            Interval = 2,
            ByWeekDay = [2, 6],
            WeekOrder = null,
            ByMonthDay = null,
            ByMonth = null
        },
        DateWiseEventCollaborators = [
            new EventCollaboratorsByDate
            {
                EventDate = new DateOnly(2024, 5, 31),
                EventCollaborators = [
                    new EventCollaborator
                    {
                        EventCollaboratorRole = Core.Entities.Enums.EventCollaboratorRole.Organizer,
                        ConfirmationStatus = Core.Entities.Enums.ConfirmationStatus.Accept,
                        ProposedDuration = null,
                        EventDate = new DateOnly(2024, 5, 31),
                        User = new User
                        {
                            Id = 49,
                            Name = "b",
                            Email = "b@gmail.com",
                            Password = "b"
                        },
                        EventId = 47
                    },
                    new EventCollaborator
                    {
                        EventCollaboratorRole = Core.Entities.Enums.EventCollaboratorRole.Participant,
                        ConfirmationStatus = Core.Entities.Enums.ConfirmationStatus.Accept,
                        ProposedDuration = null,
                        EventDate = new DateOnly(2024, 5, 31),
                        User = new User
                        {
                            Id = 48,
                            Name = "a",
                            Email = "a@gmail.com",
                            Password = "a"
                        },
                        EventId = 47
                    }
                ]
            }
        ]
    },
            new()
    {
        Id = 2205,
        Title = "event 1",
        Location = "event 1",
        Description = "event 1",
        Duration = new Duration()
        {
            StartHour = 1,
            EndHour = 2
        },
        RecurrencePattern = new RecurrencePattern()
        {
            StartDate = new DateOnly(2024, 5, 31),
            EndDate = new DateOnly(2024, 8, 25),
            Frequency = Core.Entities.Enums.Frequency.Weekly,
            Interval = 2,
            ByWeekDay = [2, 6],
            WeekOrder = null,
            ByMonthDay = null,
            ByMonth = null
        },
        DateWiseEventCollaborators = [
            new EventCollaboratorsByDate
            {
                EventDate = new DateOnly(2024, 5, 31),
                EventCollaborators = [
                    new EventCollaborator
                    {
                        EventCollaboratorRole = Core.Entities.Enums.EventCollaboratorRole.Organizer,
                        ConfirmationStatus = Core.Entities.Enums.ConfirmationStatus.Accept,
                        ProposedDuration = null,
                        EventDate = new DateOnly(2024, 5, 31),
                        User = new User
                        {
                            Id = 48,
                            Name = "a",
                            Email = "a@gmail.com",
                            Password = "a"
                        },
                        EventId = 47
                    },
                    new EventCollaborator
                    {
                        EventCollaboratorRole = Core.Entities.Enums.EventCollaboratorRole.Participant,
                        ConfirmationStatus = Core.Entities.Enums.ConfirmationStatus.Accept,
                        ProposedDuration = null,
                        EventDate = new DateOnly(2024, 5, 31),
                        User = new User
                        {
                            Id = 49,
                            Name = "b",
                            Email = "b@gmail.com",
                            Password = "b"
                        },
                        EventId = 47
                    },
                ]
            }
        ]
    },
            new()
    {
        Id = 2205,
        Title = "event 2",
        Location = "event 2",
        Description = "event 2",
        Duration = new Duration()
        {
            StartHour = 1,
            EndHour = 2
        },
        RecurrencePattern = new RecurrencePattern()
        {
            StartDate = new DateOnly(2024, 6, 2),
            EndDate = new DateOnly(2024, 6, 2),
            Frequency = Core.Entities.Enums.Frequency.Weekly,
            Interval = 2,
            ByWeekDay = [2, 6],
            WeekOrder = null,
            ByMonthDay = null,
            ByMonth = null
        },
        DateWiseEventCollaborators = [
            new EventCollaboratorsByDate
            {
                EventDate = new DateOnly(2024, 6, 2),
                EventCollaborators = [
                    new EventCollaborator
                    {
                        EventCollaboratorRole = Core.Entities.Enums.EventCollaboratorRole.Organizer,
                        ConfirmationStatus = Core.Entities.Enums.ConfirmationStatus.Accept,
                        ProposedDuration = null,
                        EventDate = new DateOnly(2024, 6, 2),
                        User = new User
                        {
                            Id = 48,
                            Name = "a",
                            Email = "a@gmail.com",
                            Password = "a"
                        },
                        EventId = 47
                    },
                    new EventCollaborator
                    {
                        EventCollaboratorRole = Core.Entities.Enums.EventCollaboratorRole.Participant,
                        ConfirmationStatus = Core.Entities.Enums.ConfirmationStatus.Pending,
                        ProposedDuration = null,
                        EventDate = new DateOnly(2024, 6, 2),
                        User = new User
                        {
                            Id = 49,
                            Name = "b",
                            Email = "b@gmail.com",
                            Password = "b"
                        },
                        EventId = 47
                    },
                ]
            }
        ]
    }
        ];
    }

    [Fact]
    public async Task Should_ReturnListOfEvent_When_SharedCalendarWithIdAvailable()
    {
        SharedCalendar sharedCalendar = new()
        {
            Id = 1,
            Sender = new()
            {
                Id = 1,
                Name = "a",
                Email = "a@gmail.com",
                Password = "a"
            },
            Receiver = new()
            {
                Id = 2,
                Name = "b",
                Email = "b@gmail.com",
                Password = "b"
            },
            FromDate = new DateOnly(),
            ToDate = new DateOnly(),
        };

        _sharedCalendarService.GetSharedCalendarById(48).Returns(sharedCalendar);

        _eventRepository.GetSharedEvents(sharedCalendar).Returns(_events);

        List<Event> events = await _eventService.GetSharedEvents(48);

        Assert.Equal(_events.Count, events.Count);

        Assert.Equal(_events, events);

        await _eventRepository.Received().GetSharedEvents(sharedCalendar);
    }

    [Fact]
    public async Task Should_ReturnEmptyList_When_SharedCalendarWithIdNotAvailable()
    {
        SharedCalendar sharedCalendar = new()
        {
            Id = 1,
            Sender = new()
            {
                Id = 1,
                Name = "a",
                Email = "a@gmail.com",
                Password = "a"
            },
            Receiver = new()
            {
                Id = 2,
                Name = "b",
                Email = "b@gmail.com",
                Password = "b"
            },
            FromDate = new DateOnly(),
            ToDate = new DateOnly(),
        };

        _sharedCalendarService.GetSharedCalendarById(48).ReturnsNull();

        _eventRepository.GetSharedEvents(sharedCalendar).Returns([]);

        List<Event> events = await _eventService.GetSharedEvents(48);

        Assert.Equal(0, events.Count);

        Assert.Equal([],events);

        await _eventRepository.DidNotReceive().GetSharedEvents(sharedCalendar);
    }
}