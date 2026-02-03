using Common.Constants;
using Common.Models.Responses;
using Common.ValueObjects;
using FluentValidation;
using MediatR;

namespace ChatApp.Application.Features.Auths.Commands;

public record ForgotPasswordCommand(string Email, Actor actor) : IRequest<ApiResponse>;

public sealed class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
{
    public ForgotPasswordCommandValidator()
    {
        RuleFor(r => r.Email)
            .NotEmpty()
            .WithMessage(MessageCode.EmailIsRequired);
    }
}