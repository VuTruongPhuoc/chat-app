using ChatApp.Application.Dtos.Users;
using Common.Constants;
using Common.Models.Responses;
using Common.ValueObjects;
using FluentValidation;
using MediatR;

namespace ChatApp.Application.Features.Auth.Commands;

public record LoginCommand(LoginRequest request, Actor actor) : IRequest<ApiResponse>;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    #region Ctors

    public LoginCommandValidator()
    {
        RuleFor(r => r.request)
            .NotNull()
            .WithMessage(MessageCode.BadRequest)
            .DependentRules(() =>
            {
                RuleFor(r => r.request.Username)
                    .NotEmpty()
                    .WithMessage(MessageCode.UserNameIsRequired);
                RuleFor(r => r.request.Password)
                    .NotEmpty()
                    .WithMessage(MessageCode.PassWordIsRequired);    
            });
    }

    #endregion
}

