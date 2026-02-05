using ChatApp.Application.Dtos.Auths.Requests;
using ChatApp.Domain.Services;
using Common.Constants;
using Common.ValueObjects;
using FluentValidation;
using MediatR;

namespace ChatApp.Application.Features.Auths.Commands;

public record EmailVerificationCommand(EmailVerificationRequest request, Actor actor) : IRequest<bool>;

public sealed class EmailVerificationCommandValidator : AbstractValidator<EmailVerificationCommand>
{
    public EmailVerificationCommandValidator()
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
            });
    }
}

public sealed class EmailVerificationCommandHandler(IIdentityService identityService) : IRequestHandler<EmailVerificationCommand, bool>
{
    public Task<bool> Handle(EmailVerificationCommand command, CancellationToken cancellationToken)
    {
        return identityService.EmailVerificationAsync(command.request, cancellationToken);
    }
}