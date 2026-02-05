using ChatApp.Application.Dtos.Auths.Requests;
using ChatApp.Domain.Services;
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

public class LoginCommandHandler(IIdentityService identityService) : IRequestHandler<LoginCommand, ApiResponse>
{

    public async Task<ApiResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        return await identityService.LoginAsync(command.request, cancellationToken);
    }
}

