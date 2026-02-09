using AutoMapper;
using BuildingBlocks.CQRS;
using ChatApp.Application.Dtos.Servers.Responses;
using ChatApp.Domain.Repositories;
using Common.Constants;

namespace ChatApp.Application.Features.Servers.Queries;

public sealed record GetServerQuery(Guid Id) : IQuery<ServerResponse>;

public sealed class GetServerQueryHandler(IServerRepository serverRepository, IMapper mapper) : IQueryHandler<GetServerQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetServerQuery query, CancellationToken cancellationToken)
    {
        var server = await serverRepository.GetByIdAsync(query.Id, cancellationToken);
        
        if (server == null)
        {
            throw new ArgumentException(MessageCode.ServerNotFound);
        }

        var response = mapper.Map<ServerResponse>(server);
        
        return response;
    }
}
