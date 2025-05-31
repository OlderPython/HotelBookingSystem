using HotelBookingSystem.Entities;
using HotelBookingSystem.Services.Hotel;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HotelController(IHotelService hotelService) : ControllerBase
{
    [HttpGet(Name = nameof(GetHotelsList))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Hotel>))]
    public async Task<IActionResult> GetHotelsList()
    {
        var properties = await hotelService.GetAllHotelsAsync();
        return Ok(properties);
    }

    [HttpGet("{id}", Name = nameof(GetHotelById))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Hotel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetHotelById(int id)
    {
        var property = await hotelService.GetHotelByIdAsync(id);
        if (property == null)
        {
            return NotFound();
        }
        return Ok(property);
    }

    [HttpPost(Name = nameof(CreateHotel))]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Hotel))]
    public async Task<IActionResult> CreateHotel([FromBody] Hotel hotel)
    {
        var createdProperty = await hotelService.CreateHotelAsync(hotel);
        return CreatedAtAction(nameof(GetHotelById), new { id = createdProperty.Id }, createdProperty);
    }

    [HttpPut("{id}", Name = nameof(UpdateHotel))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Hotel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateHotel(int id, [FromBody] Hotel hotel)
    {
        var updatedProperty = await hotelService.UpdateHotelAsync(id, hotel);
        if (updatedProperty == null)
        {
            return NotFound();
        }
        return Ok(updatedProperty);
    }

    [HttpDelete("{id}", Name = nameof(DeleteHotel))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteHotel(int id)
    {
        var success = await hotelService.DeleteHotelAsync(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }
}