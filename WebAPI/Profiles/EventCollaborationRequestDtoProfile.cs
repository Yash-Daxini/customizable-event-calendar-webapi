﻿using AutoMapper;
using Core.Entities;
using Core.Entities.Enums;
using Infrastructure.Extensions;
using WebAPI.Dtos;

namespace WebAPI.Profiles;

public class EventCollaborationRequestDtoProfile : Profile
{
    public EventCollaborationRequestDtoProfile()
    {
        CreateMap<EventCollaborationRequestDto, EventCollaborator>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => new User { Id = src.UserId }))
            .ForMember(dest => dest.ConfirmationStatus, opt => opt.MapFrom(src => src.ConfirmationStatus.ToEnum<ConfirmationStatus>()))
            .ForMember(dest => dest.EventCollaboratorRole, opt => opt.MapFrom(src => src.EventCollaboratorRole.ToEnum<EventCollaboratorRole>()));
    }
}
