using HotelBookingSystem.Entities;

namespace HotelBookingSystem.Services.Room;

public class RoomService : IRoomService
{
    private static List<Entities.Room> _rooms = new()
    {
        new Entities.Room { Id = 1, Price = 4324, Available = true, Number = 2 },
        new Entities.Room { Id = 2, Available = true, Number = 5, Price = 432576, }
    };

    public List<Entities.Room> GetAllRooms()
    {
        return _rooms;
    }

    public Entities.Room GetRoomById(int id)
    {
        return _rooms.FirstOrDefault(t => t.Id == id);
    }

    public Entities.Room CreateRoom(Entities.Room room)
    {
        room.Id = _rooms.Max(t => t.Id) + 1;
        _rooms.Add(room);
        return room;
    }

    public Entities.Room UpdateRoom(int id, Entities.Room room)
    {
        var existingTenant = _rooms.FirstOrDefault(t => t.Id == id);
        if (existingTenant == null) return null;

        existingTenant.Price = room.Price;
        existingTenant.Available = room.Available;
        existingTenant.Number = room.Number;

        return existingTenant;
    }

    public bool DeleteRoom(int id)
    {
        var tenant = _rooms.FirstOrDefault(t => t.Id == id);
        if (tenant == null) return false;

        _rooms.Remove(tenant);
        return true;
    }
}