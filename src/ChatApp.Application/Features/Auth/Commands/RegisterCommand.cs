using ChatApp.Application.Dtos.Users;
using Common.Constants;
using Common.Models.Responses;
using Common.ValueObjects;
using FluentValidation;
using MediatR;

namespace ChatApp.Application.Features.Auth.Commands;

public record RegisterCommand(RegisterRequest request, Actor actor) : IRequest<ApiResponse>;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    #region Ctors

    public RegisterCommandValidator()
    {
        RuleFor(r => r.request)
            .NotNull()
            .WithMessage(MessageCode.BadRequest)
            .DependentRules(() =>
            {
                RuleFor(r => r.request.Username)
                    .NotEmpty()
                    .WithMessage(MessageCode.UserNameIsRequired);
                RuleFor(r => r.request.Email)
                    .NotEmpty()
                    .WithMessage(MessageCode.EmailIsRequired)
                    .EmailAddress()
                    .WithMessage(MessageCode.InvalidEmailFormat);
                RuleFor(r => r.request.Password)
                    .NotEmpty()
                    .WithMessage(MessageCode.PassWordIsRequired);    
            });
    }

    #endregion
}
