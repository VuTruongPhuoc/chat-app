using ChatApp.Application.Dtos.Auths.Requests;
using ChatApp.Application.Dtos.Auths.Responses;
using ChatApp.Domain.Services;
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
                RuleFor(r => r.request.ConfirmNewPassword)
                    .NotEmpty()
                    .WithMessage(MessageCode.PassWordIsRequired);
                RuleFor(r => r.request.ConfirmNewPassword)
                    .Equal(x => x.request.NewPassword)
                    .WithMessage(MessageCode.NewPasswordNotMatch);
            });
    }
}

public sealed class ResetPasswordCommandHandler(IIdentityService identityService) : IRequestHandler<ResetPasswordCommand, ApiResponse>
{
    public Task<ApiResponse> Handle(ResetPasswordCommand command, CancellationToken cancellationToken)
    {
        return identityService.ResetPasswordAsync(command.request, cancellationToken);
    }
}