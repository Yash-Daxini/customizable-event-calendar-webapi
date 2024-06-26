﻿namespace WebAPI.Dtos;

public class EventCollaboratorResponseDto
{
    public int Id { get; set; }

    public int EventId { get; set; }

    public UserDto User { get; set; }

    public string EventCollaboratorRole { get; set; }

    public string ConfirmationStatus { get; set; }

    public DurationDto? ProposedDuration { get; set; }

    public DateOnly EventDate { get; set; }
}
