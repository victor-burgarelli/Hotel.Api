using Hotel.Api.Models;
using Hotel.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        IHotelService _hotelService;

        public HotelController(IHotelService service) 
        {
            _hotelService = service;
        }
        
        [HttpGet]
        [Route("[action]/id")]
        /// <summary>
        /// Get a hotel by its identifier
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns>Object of type HotelsModel </returns>
        public IActionResult GetHotelById(int id)
        {
            try 
            {
                var hotel = _hotelService.GetHotelById(id);
                
                if (hotel is null) return NotFound();
                
                return Ok(hotel);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get a list of all hotels
        /// </summary>
        /// <returns>A list of type HotelsModel</returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllHotels()
        {
            try 
            {
                var hotels = _hotelService.GetAllHotels();
                
                return Ok(hotels);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("[action]")]
        /// <summary>
        /// add new hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns>Status and message </returns>
        public IActionResult AddHotel(HotelsModel request)
        {
            try 
            {
                var response = _hotelService.AddHotel(request);
                return Ok(response);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// add new category
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Status and message </returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult AddCategory(CategoriesModel request) 
        {
            try
            {
                var response = _hotelService.AddCategory(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Edit hotel information
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns>Status and message </returns>
        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateHotel(HotelsModel request) 
        {
            ResponseModel response = new();

            try
            {
                response = _hotelService.UpdateHotel(request);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(response);
            }
        }

        [HttpDelete]
        [Route("[action]")]
        /// <summary>
        /// Delete a hotel by its identifier
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns>Status and message </returns>
        public IActionResult DeleteHotel(int id)
        {
            ResponseModel response = new();

            try
            {
                response = _hotelService.DeleteHotel(id);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(response);
            }
        }
    }
}
