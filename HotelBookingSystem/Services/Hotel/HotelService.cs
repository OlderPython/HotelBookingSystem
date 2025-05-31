namespace HotelBookingSystem.Services.Hotel;

public class HotelService : IHotelService
{
    private static List<Entities.Hotel> _hotels = new()
    {
        new Entities.Hotel { Id = 1, Address = "123 Main St", Name = "Hotel 1", Rating = 4.6m },
        new Entities.Hotel { Id = 2, Address = "456 Oak St", Name = "Hotel 2", Rating = 4.7m },
    };

    public Task<IEnumerable<Entities.Hotel>> GetAllHotelsAsync()
    {
        return Task.FromResult<IEnumerable<Entities.Hotel>>(_hotels);
    }

    public Task<Entities.Hotel?> GetHotelByIdAsync(int id)
    {
        var hotel = _hotels.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(hotel);
    }

    public Task<Entities.Hotel> CreateHotelAsync(Entities.Hotel hotel)
    {
        hotel.Id = _hotels.Max(p => p.Id) + 1;
        _hotels.Add(hotel);
        return Task.FromResult(hotel);
    }

    public Task<Entities.Hotel> UpdateHotelAsync(int id, Entities.Hotel hotel)
    {
        var existingHotel = _hotels.FirstOrDefault(p => p.Id == id);
        if (existingHotel == null) return Task.FromResult<Entities.Hotel>(null!);

        existingHotel.Address = hotel.Address;
        existingHotel.Rating = hotel.Rating;
        existingHotel.Name = hotel.Name;

        return Task.FromResult(existingHotel);
    }

    public Task<bool> DeleteHotelAsync(int id)
    {
        var hotel = _hotels.FirstOrDefault(p => p.Id == id);
        if (hotel == null) return Task.FromResult(false);

        _hotels.Remove(hotel);
        return Task.FromResult(true);
    }
}