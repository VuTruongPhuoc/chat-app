using ChatApp.Application.Dtos.Auths.Requests;
using ChatApp.Domain.Services;
using Common.Constants;
using Common.Models.Responses;
using Common.ValueObjects;
using FluentValidation;
using MediatR;

namespace ChatApp.Application.Features.Auths.Commands;

public record VerifyEmailCommand(VerifyEmailRequest request, Actor actor) : IRequest<ApiResponse<bool>>;

public sealed class VerifyEmailCommandValidator : AbstractValidator<VerifyEmailCommand>
{
    public VerifyEmailCommandValidator()
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

public sealed class VerifyEmailCommandHandler(IIdentityService identityService) : IRequestHandler<VerifyEmailCommand, ApiResponse<bool>>
{
    public Task<ApiResponse<bool>> Handle(VerifyEmailCommand command, CancellationToken cancellationToken)
    {
        return identityService.VerifyEmailAsync(command.request, cancellationToken);
    }
}