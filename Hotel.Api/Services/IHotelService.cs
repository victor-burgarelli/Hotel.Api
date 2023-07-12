using Hotel.Api.Models;

namespace Hotel.Api.Services

{
    public interface IHotelService
    {
        /// <summary>
        /// Get a list of all hotels
        /// </summary>
        /// <returns>A list of type HotelsModel</returns>
        List<HotelsModel> GetAllHotels();

        /// <summary>
        /// Get a hotel by its identifier
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns>Object of type HotelsModel </returns>
        HotelsModel? GetHotelById(int hotelId);

        /// <summary>
        /// Delete a hotel by its identifier
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns>Status and message </returns>
        ResponseModel DeleteHotel(int hotelId);

        /// <summary>
        /// Edit hotel information
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns>Status and message </returns>
        ResponseModel UpdateHotel(HotelsModel hotel);

        /// <summary>
        /// add new hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns>Status and message </returns>
        ResponseModel AddHotel(HotelsModel hotel);

        /// <summary>
        /// add new category
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Status and message </returns>
        ResponseModel AddCategory(CategoriesModel category);
    }
}
