

namespace HotelBookingSystem.Services.Room;

public interface IRoomService
{
    List<Entities.Room> GetAllRooms();
    Entities.Room GetRoomById(int id);
    Entities.Room CreateRoom(Entities.Room room);
    Entities.Room UpdateRoom(int id, Entities.Room room);
    bool DeleteRoom(int id);
}