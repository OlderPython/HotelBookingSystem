namespace HotelBookingSystem.Services.Hotel;

public interface IHotelService
{
    Task<IEnumerable<Entities.Hotel>> GetAllHotelsAsync();
    Task<Entities.Hotel?> GetHotelByIdAsync(int id);
    Task<Entities.Hotel> CreateHotelAsync(Entities.Hotel hotel);
    Task<Entities.Hotel> UpdateHotelAsync(int id, Entities.Hotel hotel);
    Task<bool> DeleteHotelAsync(int id);
}