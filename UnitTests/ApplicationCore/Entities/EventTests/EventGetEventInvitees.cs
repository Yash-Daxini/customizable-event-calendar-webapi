﻿using Core.Entities;
using Core.Entities.Enums;

namespace UnitTests.ApplicationCore.Entities.EventTests;

public class EventGetEventInvitees
{
    private readonly Event _event;

    private readonly List<EventCollaborator> _eventCollaborators;

    public EventGetEventInvitees()
    {
        _event = new()
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
                StartDate = new DateOnly(),
                EndDate = new DateOnly(),
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
                    EventDate = new DateOnly(),
                    EventCollaborators = [
                        new EventCollaborator
                        {
                            EventCollaboratorRole = Core.Entities.Enums.EventCollaboratorRole.Organizer,
                            ConfirmationStatus = Core.Entities.Enums.ConfirmationStatus.Accept,
                            ProposedDuration = null,
                            EventDate = new DateOnly(),
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
                            EventDate = new DateOnly(),
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
        };
        _eventCollaborators = [
                        new EventCollaborator
                        {
                            EventCollaboratorRole = EventCollaboratorRole.Organizer,
                            ConfirmationStatus = ConfirmationStatus.Accept,
                            ProposedDuration = null,
                            EventDate = new DateOnly(),
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
                            EventCollaboratorRole = EventCollaboratorRole.Participant,
                            ConfirmationStatus = ConfirmationStatus.Pending,
                            ProposedDuration = null,
                            EventDate = new DateOnly(),
                            User = new User
                            {
                                Id = 49,
                                Name = "b",
                                Email = "b@gmail.com",
                                Password = "b"
                            },
                            EventId = 47
                        },
                        ];

    }

    [Fact]
    public void GetEventInviteesAsEmptyListIfDateWiseEventCollaboratorsIsNull()
    {
        _event.DateWiseEventCollaborators = null;

        List<EventCollaborator> expectedInvitees = _event.GetEventInvitees();

        Assert.Equivalent(expectedInvitees, new List<EventCollaborator>());
    }

    [Fact]
    public void GetEventInviteesAsEmptyListIfDateWiseEventCollaboratorsIsEmpty()
    {
        _event.DateWiseEventCollaborators = [];

        List<EventCollaborator> expectedInvitees = _event.GetEventInvitees();

        Assert.Equivalent(expectedInvitees, new List<EventCollaborator>());
    }

    [Fact]
    public void GetEventInviteesIfDateWiseEventCollaboratorsIsPresent()
    {
        List<EventCollaborator> expectedInvitees = _event.GetEventInvitees();

        Assert.Equivalent(expectedInvitees, _eventCollaborators);
    }

    [Fact]
    public void GetEventInviteesIfDateWiseEventCollaboratorsContainsCollaborator()
    {
        _event.DateWiseEventCollaborators[0].EventCollaborators.Add(
            new EventCollaborator
            {
                EventCollaboratorRole = EventCollaboratorRole.Collaborator,
                ConfirmationStatus = ConfirmationStatus.Accept,
                ProposedDuration = null,
                EventDate = new DateOnly(),
                User = new User
                {
                    Id = 50,
                    Name = "c",
                    Email = "c@gmail.com",
                    Password = "c"
                },
                EventId = 47
            });

        _eventCollaborators.Add(
            new EventCollaborator
            {
                EventCollaboratorRole = EventCollaboratorRole.Collaborator,
                ConfirmationStatus = ConfirmationStatus.Accept,
                ProposedDuration = null,
                EventDate = new DateOnly(),
                User = new User
                {
                    Id = 50,
                    Name = "c",
                    Email = "c@gmail.com",
                    Password = "c"
                },
                EventId = 47
            });

        List<EventCollaborator> expectedInvitees = _event.GetEventInvitees();

        Assert.Equivalent(expectedInvitees, _eventCollaborators);
    }
}