using HotelBookingSystem.Entities;
using HotelBookingSystem.Services.Room;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomController(IRoomService roomService) : ControllerBase
{
    [HttpGet(Name = "GetRooms")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Room>))]
    public IActionResult GetAllRooms()
    {
        var rooms = roomService.GetAllRooms();
        return Ok(rooms);
    }

    [HttpGet("{id}", Name = "GetRoomById")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Room))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetRoomById(int id)
    {
        var room = roomService.GetRoomById(id);
        if (room == null)
        {
            return NotFound();
        }

        return Ok(room);
    }

    [HttpPost(Name = nameof(CreateRoom))]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Room))]
    public IActionResult CreateRoom([FromBody] Room room)
    {
        var createdRoom = roomService.CreateRoom(room);
        return CreatedAtAction(nameof(GetRoomById), new { id = createdRoom.Id }, createdRoom);
    }

    [HttpPut("{id}", Name = nameof(UpdateRoom))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Room))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult UpdateRoom(int id, [FromBody] Room room)
    {
        var updatedRoom = roomService.UpdateRoom(id, room);
        if (updatedRoom == null)
        {
            return NotFound();
        }

        return Ok(updatedRoom);
    }

    [HttpDelete("{id}", Name = nameof(DeleteRoom))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeleteRoom(int id)
    {
        var deleted = roomService.DeleteRoom(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}