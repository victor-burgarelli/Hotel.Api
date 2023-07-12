using Hotel.Api.Context;
using Hotel.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Api.Services
{
    public class HotelService : IHotelService
    {
        private ApplicationDbContext _context;

        public HotelService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// add new category
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Status and message </returns>
        public ResponseModel AddCategory(CategoriesModel category)
        {
            ResponseModel response = new();

            try
            {
                _context.Add(category);
                _context.SaveChanges();
                response.Message = "Category Inserted Successfully";
                response.Status = "Success";
                response.Data = category;
            }
            catch (Exception Ex)
            {
                response.Message = Ex.Message;
                response.Status = "Error";
                response.Data = null;
            }

            return response;
        }

        /// <summary>
        /// add new hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns>Status and message </returns>
        public ResponseModel AddHotel(HotelsModel hotel)
        {
            ResponseModel response = new();

            try
            {
                hotel.Id = 0;
                var category = _context.Categories.Find(hotel.CategoryId);

                if (category != null)
                {
                    hotel.Category = category;
                }

                else
                {
                    throw new Exception("Category not found");
                }

                _context.Add(hotel);
                _context.SaveChanges();

                if (hotel.Address != null)
                {
                    hotel.AddressId = hotel.Address.Id;
                    _context.Update(hotel);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Address cant be null");
                }

                response.Message = "Hotel Inserted Successfully";
                response.Status = "Success";
                response.Data = hotel;
            }
            catch (Exception Ex)
            {
                response.Message = Ex.Message;
                response.Status = "Error";
                response.Data = null;
            }

            return response;
        }

        /// <summary>
        /// Delete a hotel by its identifier
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns>Status and message </returns>
        public ResponseModel DeleteHotel(int hotelId)
        {
            ResponseModel response = new();

            try
            {
                HotelsModel? hotel = GetHotelById(hotelId);

                if (hotel is not null)
                {
                    _context.Remove(hotel);
                    _context.SaveChanges();
                    response.Message = "Hotel removed Successfully";
                    response.Status = "Success";
                    response.Data = hotel;
                }
                else
                {
                    throw new Exception("Hotel not found");
                }
            }
            catch (Exception Ex)
            {
                response.Message = Ex.Message;
                response.Status = "Error";
            }

            return response;
        }

        /// <summary>
        /// Get a list of all hotels
        /// </summary>
        /// <returns>A list of type HotelsModel</returns>
        public List<HotelsModel> GetAllHotels()
        {
            List<HotelsModel> hotels;
            try
            {
                hotels = _context.Set<HotelsModel>()
                    .Include(h => h.Address)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return hotels;
        }

        /// <summary>
        /// Get a hotel by its identifier
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns>Object of type HotelsModel </returns>
        public HotelsModel? GetHotelById(int hotelId)
        {
            HotelsModel? hotel;
            try
            {
                hotel = _context.Set<HotelsModel>()
                .Include(h => h.Address)
                .FirstOrDefault(h => h.Id == hotelId);
            }
            catch (Exception)
            {
                throw;
            }

            return hotel;
        }

        /// <summary>
        /// Edit hotel information
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns>Status and message </returns>
        public ResponseModel UpdateHotel(HotelsModel hotel)
        {
            ResponseModel response = new();
            HotelsModel? hotelOld = GetHotelById(hotel.Id);

            try
            {
                if (hotelOld is not null)
                {
                    hotelOld.Name = hotel.Name;
                    hotelOld.Address = hotel.Address;
                    hotelOld.PricePerNight = hotel.PricePerNight;
                    
                    var category = _context.Categories.Find(hotel.CategoryId);

                    if (category != null)
                    {
                        hotelOld.Category = category;
                        hotelOld.CategoryId = hotel.CategoryId;
                    }
                    else
                    {
                        throw new Exception("Category not found");
                    }

                    _context.Update(hotelOld);
                    _context.SaveChanges();

                    response.Message = "Hotel updated Successfully";
                    response.Status = "Success";
                    response.Data = hotelOld;
                }
                else
                {
                    throw new Exception("Hotel not found");
                }
            }
            catch (Exception Ex)
            {
                response.Message = Ex.Message;
                response.Status = "Error";
                response.Data = null;
            }

            return response;
        }
    }
}
