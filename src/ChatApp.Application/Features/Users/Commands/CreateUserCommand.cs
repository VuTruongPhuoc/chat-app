using ChatApp.Application.Dtos.Users.Requests;
using Common.ValueObjects;
using Common.Constants;
using FluentValidation;
using MediatR;

namespace ChatApp.Application.Features.Users.Commands;

public record CreateUserCommand(UpsertUserRequest request, Actor actor) : IRequest<Guid>;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    #region Ctor

    public CreateUserCommandValidator()
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