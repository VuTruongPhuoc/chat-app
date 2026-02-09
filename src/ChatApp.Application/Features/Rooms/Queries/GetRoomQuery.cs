using AutoMapper;
using BuildingBlocks.CQRS;
using ChatApp.Application.Dtos.Rooms.Responses;
using ChatApp.Domain.Repositories;
using Common.Constants;

namespace ChatApp.Application.Features.Rooms.Queries;

public sealed record GetRoomQuery(Guid Id) : IQuery<RoomResponse>;

public sealed class GetRoomQueryHandler(IRoomRepository roomRepository, IMapper mapper) : IQueryHandler<GetRoomQuery, RoomResponse>
{
    public async Task<RoomResponse> Handle(GetRoomQuery query, CancellationToken cancellationToken)
    {
        var room = await roomRepository.GetByIdAsync(query.Id, cancellationToken);
        
        if (room == null)
        {
            throw new ArgumentException(MessageCode.RoomNotFound);
        }

        var response = mapper.Map<RoomResponse>(room);
        
        return response;
    }
}