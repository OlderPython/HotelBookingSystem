namespace HotelBookingSystem.Entities;

public record Room
{
    public int Id { get; set; } 
  
    public int Number { get; set; }
    
    
    public decimal Price { get; set; }
    
    public bool Available { get; set; }
}