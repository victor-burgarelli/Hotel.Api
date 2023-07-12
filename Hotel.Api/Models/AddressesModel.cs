using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Hotel.Api.Models
{
    /// <summary>
    /// Class that represents the Address entity.
    /// </summary>
    public class AddressesModel
    {
        public AddressesModel() 
        {
            Hotel = new();
        }

        [Key]
        /// <summary>
        /// Address identifier.
        /// </summary>
        public int Id { get;  private set; }

        /// <summary>
        /// Address street.
        /// </summary>
        public string? Street { get; set; }

        /// <summary>
        /// Address city.
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// Address state.
        /// </summary>
        public string? State { get; set; }

        /// <summary>
        /// Address CEP.
        /// </summary>
        public string? ZipCode { get; set; }

        [JsonIgnore]
        /// <summary>
        /// Hotel associated with the address.
        /// </summary>
        public int HotelId { get; set; }

        [JsonIgnore]
        /// <summary>
        /// Hotel associated with the address for navigation.
        /// </summary>
        public HotelsModel Hotel { get; set; }
    }
}
