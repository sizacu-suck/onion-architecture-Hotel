using HotelApi.Domain;
using HotelApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IRoomService clientDomen;

        public ClientController(IRoomService _clientDomen)
        {
            clientDomen = _clientDomen;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> StatusRoom(int id)
        {
            try
            {
                await clientDomen.CheckRoom(id);
                return Ok();
            }
            catch (RoomNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (RoomNotBookedException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> TakeRoom(int id)
        {
            try
            {
                await clientDomen.TakeRoom(id);
                return Ok(new { message = "Комната успешно забронирована"});
            }
            catch (RoomNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (RoomNotBookedException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
