using ChatApp.Application.Dtos.Auths.Requests;
using Common.Constants;
using Common.Models.Responses;
using Common.ValueObjects;
using FluentValidation;
using MediatR;

namespace ChatApp.Application.Features.Auths.Commands;

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
                RuleFor(r => r.request.UserName)
                    .NotEmpty()
                    .WithMessage(MessageCode.UserNameIsRequired);
                RuleFor(r => r.request.PassWord)
                    .NotEmpty()
                    .WithMessage(MessageCode.PassWordIsRequired);    
            });
    }

    #endregion
}

