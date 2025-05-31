namespace HotelBookingSystem.Entities;

public record Hotel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }
    

    public decimal Rating { get; set; }
}