using ChatApp.Application.Dtos.Auths.Requests;
using ChatApp.Application.Dtos.Auths.Responses;
using Common.Constants;
using Common.Models.Responses;
using Common.ValueObjects;
using FluentValidation;
using MediatR;

namespace ChatApp.Application.Features.Auths.Commands;

public record ResetPasswordCommand(ResetPasswordRequest request, Actor actor) : IRequest<ApiResponse>;

public sealed class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
{
    public ResetPasswordCommandValidator()
    {
        RuleFor(r => r.request)
            .NotNull()
            .WithMessage(MessageCode.BadRequest)
            .DependentRules(() =>
            {
                RuleFor(r => r.request.Email)
                    .NotEmpty()
                    .WithMessage(MessageCode.EmailIsRequired)
                    .EmailAddress()
                    .WithMessage(MessageCode.InvalidEmailFormat);
                RuleFor(r => r.request.NewPassword)
                    .NotEmpty()
                    .WithMessage(MessageCode.PassWordIsRequired);

            });
    }
}