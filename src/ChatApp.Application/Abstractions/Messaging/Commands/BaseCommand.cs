using BuildingBlocks.CQRS;
using Common.ValueObjects;
using MediatR;

namespace ChatApp.Application.Abstractions.Messaging.Commands;

public abstract record BaseCommand<TRequest, TResponse>(
    TRequest request, 
    Actor actor
) : ICommand<TResponse> 
    where TRequest : class 
    where TResponse : notnull;