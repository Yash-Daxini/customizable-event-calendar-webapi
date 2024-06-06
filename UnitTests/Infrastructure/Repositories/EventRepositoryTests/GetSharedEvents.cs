﻿using AutoMapper;
using Core.Entities;
using Infrastructure;
using Infrastructure.Profiles;
using Infrastructure.Repositories;

namespace UnitTests.Infrastructure.Repositories.EventRepositoryTests;

public class GetSharedEvents
{
    private DbContextEventCalendar _dbContextEvent;
    private readonly IMapper _mapper;
    private readonly List<Event> _events;

    public GetSharedEvents()
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new EventProfile());
            mc.AddProfile(new UserProfile());
            mc.AddProfile(new EventCollaboratorProfile());
            mc.AddProfile(new UserProfile());
            mc.AddProfile(new SharedCalendarProfile());
        });
        IMapper mapper = mappingConfig.CreateMapper();
        _mapper = mapper;

        _events = [
            new() {
                Id = 1,
                Title = "Test",
                Description = "Test",
                Location = "Test",
                Duration = new Duration(1,2),
                RecurrencePattern = new (){
                    StartDate = new DateOnly(2024, 6, 7),
                    EndDate = new DateOnly(2024, 6, 7),
                    Frequency = Core.Entities.Enums.Frequency.None,
                    Interval = 1,
                    ByMonth = null,
                    ByMonthDay = null,
                    WeekOrder = null,
                },
                DateWiseEventCollaborators = [
                    new (){
                        EventDate = new DateOnly(2024, 6, 7),
                        EventCollaborators = [
                            new (){
                                Id = 1,
                                EventDate = new DateOnly(2024, 6, 7),
                                EventId = 1,
                                EventCollaboratorRole = Core.Entities.Enums.EventCollaboratorRole.Organizer,
                                ConfirmationStatus = Core.Entities.Enums.ConfirmationStatus.Accept,
                                ProposedDuration = null,
                                User = new(){
                                    Id = 1,
                                    Name = "a",
                                    Email = "a",
                                    Password = "a",
                                }
                            }
                            ]
                    }
                    ]
        },new() {
                Id = 2,
                Title = "Test1",
                Description = "Test1",
                Location = "Test1",
                Duration = new Duration(2,3),
                RecurrencePattern = new (){
                    StartDate = new DateOnly(2024, 6, 7),
                    EndDate = new DateOnly(2024, 6, 7),
                    Frequency = Core.Entities.Enums.Frequency.Daily,
                    Interval = 1,
                    ByMonth = null,
                    ByMonthDay = null,
                    WeekOrder = null,
                },
                DateWiseEventCollaborators = [
                    new (){
                        EventDate = new DateOnly(2024, 6, 7),
                        EventCollaborators = [
                            new (){
                                Id = 2,
                                EventDate = new DateOnly(2024, 6, 7),
                                EventId = 2,
                                EventCollaboratorRole = Core.Entities.Enums.EventCollaboratorRole.Organizer,
                                ConfirmationStatus = Core.Entities.Enums.ConfirmationStatus.Accept,
                                ProposedDuration = null,
                                User = new(){
                                    Id = 2,
                                    Name = "b",
                                    Email = "b",
                                    Password = "b",
                                }
                            },
                            new (){
                                Id = 3,
                                EventDate = new DateOnly(2024, 6, 7),
                                EventId = 2,
                                EventCollaboratorRole = Core.Entities.Enums.EventCollaboratorRole.Participant,
                                ConfirmationStatus = Core.Entities.Enums.ConfirmationStatus.Pending,
                                ProposedDuration = null,
                                User = new(){
                                    Id = 3,
                                    Name = "c",
                                    Email = "c",
                                    Password = "c",
                                }
                            }
                            ]
                    }
                    ]
        }
            ];
    }

    [Fact]
    public async Task Should_ReturnListOfEvents_When_SharedCalendarAvailableWithGivenId()
    {
        _dbContextEvent = await new EventRepositoryDBContext().GetDatabaseContext();

        EventRepository eventRepository = new(_dbContextEvent, _mapper);

        _events.RemoveAt(1);

        SharedCalendar sharedCalendar = _mapper.Map<SharedCalendar>(_dbContextEvent.SharedCalendars.First());

        List<Event> actualResult = await eventRepository.GetSharedEvents(sharedCalendar);

        Assert.Equivalent(_events,actualResult);
    }
}
