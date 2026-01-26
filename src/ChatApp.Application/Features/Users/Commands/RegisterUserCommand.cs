using ChatApp.Application.Dtos.Users;
using Common.ValueObjects;
using Common.Constants;
using FluentValidation;
using MediatR;

namespace ChatApp.Application.Features.Users.Commands;

public record RegisterUserCommand(RegisterUserRequest request, Actor actor) : IRequest<Guid>;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    #region Ctor

    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.request)
            .NotNull()
            .WithMessage(MessageCode.BadRequest)
            .DependentRules(() =>
            {
                RuleFor(x => x.request.UserName)
                    .NotEmpty()
                    .WithMessage(MessageCode.UserNameIsRequired);
                RuleFor(x => x.request.Email)
                    .NotEmpty()
                    .WithMessage(MessageCode.EmailIsRequired)
                    .EmailAddress()
                    .WithMessage(MessageCode.InvalidEmailFormat);
            });
    }

    #endregion 
}