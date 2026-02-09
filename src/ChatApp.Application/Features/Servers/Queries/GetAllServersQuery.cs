using AutoMapper;
using BuildingBlocks.CQRS;
using ChatApp.Application.Dtos.Servers.Responses;
using ChatApp.Domain.Repositories;

namespace ChatApp.Application.Features.Servers.Queries;

public sealed class GetAllServersQuery : IQuery<List<ServerResponse>>;

public sealed class GetAllServersQueryHandler(IServerRepository serverRepository, IMapper mapper) : IQueryHandler<GetAllServersQuery, List<ServerResponse>>
{
    public async Task<List<ServerResponse>> Handle(GetAllServersQuery request, CancellationToken cancellationToken)
    {
        var servers = await serverRepository.GetAllAsync(cancellationToken);
        var responses = mapper.Map<List<ServerResponse>>(servers);
        
        return responses;
    }
}
