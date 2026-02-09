using AutoMapper;
using BuildingBlocks.CQRS;
using ChatApp.Application.Dtos.Rooms.Responses;
using ChatApp.Domain.Repositories;

namespace ChatApp.Application.Features.Rooms.Queries;

public sealed class GetAllRoomsQuery : IQuery<List<GetAllRoomsResponse>>;

public sealed class GetAllRoomsQueryHandler(IRoomRepository roomRepository, IMapper mapper) : IQueryHandler<GetAllRoomsQuery, List<GetAllRoomsResponse>>
{
    public async Task<List<GetAllRoomsResponse>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
    {
        var rooms = await roomRepository.GetAllAsync(cancellationToken);
        var responses = mapper.Map<List<GetAllRoomsResponse>>(rooms);
        
        return responses;
    }
}