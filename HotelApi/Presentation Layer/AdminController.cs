using HotelApi.Business_Layer;
using HotelApi.Domen;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Presentation_Layer
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IRoomService roomDomen;

        public AdminController(IRoomService _roomDomen)
        {
            roomDomen = _roomDomen;
        }

        [HttpGet]
        public async Task<IActionResult> GetallRoom()
        {
            var Rooms = await roomDomen.GetAll();
            return Ok(Rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {
            try
            {
                var room = await roomDomen.GetRoom(id);
                return Ok(room);
            }
            catch (RoomNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoomClass room)
        {
            try
            {
                await roomDomen.CreateRoom(room);
                return Created();
            }
            catch (InvalidRoomPriceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidRoomDescriptionException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RoomClass room)
        {
            try
            {
                await roomDomen.PutRoom(room);
                return Ok();
            }
            catch (InvalidRoomPriceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidRoomDescriptionException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (RoomNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await roomDomen.DeleteRoom(id);
                return Ok();
            }
            catch (RoomNotEmptyException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (RoomNotFoundException)
            {
                return NotFound($"Комната {id} не найдена");
            }
        }
    }
}
