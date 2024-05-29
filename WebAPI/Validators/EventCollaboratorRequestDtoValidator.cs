﻿using Core.Domain.Enums;
using FluentValidation;
using WebAPI.Dtos;

namespace WebAPI.Validators
{
    public class EventCollaboratorRequestDtoValidator : AbstractValidator<EventCollaboratorRequestDto>
    {
        public EventCollaboratorRequestDtoValidator()
        {
            RuleFor(e => e.User)
                .NotNull()
                .SetValidator(new UserDtoValidator());


            RuleFor(e => e.ParticipantRole)
                .NotEmpty()
                .NotNull()
                .IsEnumName(typeof(ParticipantRole));

            RuleFor(e => e.ConfirmationStatus)
                .NotEmpty()
                .NotNull()
                .IsEnumName(typeof(ConfirmationStatus));
        }
    }
}
