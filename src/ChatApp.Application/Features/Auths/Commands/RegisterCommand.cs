using ChatApp.Application.Dtos.Auths.Requests;
using ChatApp.Domain.Services;
using Common.Constants;
using Common.Models.Responses;
using Common.ValueObjects;
using FluentValidation;
using MediatR;

namespace ChatApp.Application.Features.Auths.Commands;

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
                RuleFor(r => r.request.UserName)
                    .NotEmpty()
                    .WithMessage(MessageCode.UserNameIsRequired);
                RuleFor(r => r.request.Email)
                    .NotEmpty()
                    .WithMessage(MessageCode.EmailIsRequired)
                    .EmailAddress()
                    .WithMessage(MessageCode.InvalidEmailFormat);
                RuleFor(r => r.request.PassWord)
                    .NotEmpty()
                    .WithMessage(MessageCode.PassWordIsRequired);    
            });
    }

    #endregion
}

public class RegisterCommandHandler(IIdentityService identityService) : IRequestHandler<RegisterCommand, ApiResponse>
{

    public async Task<ApiResponse> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        return await identityService.RegisterAsync(command.request, cancellationToken);
    }
}

