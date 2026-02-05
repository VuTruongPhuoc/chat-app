using ChatApp.Domain.Services;
using Common.Constants;
using Common.Models.Responses;
using Common.ValueObjects;
using FluentValidation;
using MediatR;

namespace ChatApp.Application.Features.Auths.Commands;

public record ResentVerificationEmailCommand(string Email, Actor actor) : IRequest<ApiResponse<bool>>;

public sealed class ResentVerificationEmailCommandValidator : AbstractValidator<ResentVerificationEmailCommand>
{
    public ResentVerificationEmailCommandValidator()
    {
        RuleFor(r => r.Email)
            .NotEmpty()
            .WithMessage(MessageCode.EmailIsRequired);
    }
}

public sealed class ResentVerificationEmailCommandHandler(IIdentityService identityService) : IRequestHandler<ResentVerificationEmailCommand, ApiResponse<bool>>
{
    public Task<ApiResponse<bool>> Handle(ResentVerificationEmailCommand command, CancellationToken cancellationToken)
    {
        return identityService.ResentVerificationEmailAsync(command.Email, cancellationToken);
    }
}