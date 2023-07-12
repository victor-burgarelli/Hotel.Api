using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text.Json.Serialization;

namespace Hotel.Api.Models
{
    /// <summary>
    /// Class that represents the Hotel entity.
    /// </summary>
    public class HotelsModel
    {
        public HotelsModel() 
        {
            Category ??= new CategoriesModel();
        }

        [Key]
        /// <summary>
        /// Hotel identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Hotel name.
        /// </summary>
        public string? Name { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        /// <summary>
        /// Price per night at the hotel.
        /// </summary>
        public decimal PricePerNight { get; set; }

        /// <summary>
        /// Hotel rating.
        /// </summary>
        public double Rating { get; set; }

        /// <summary>
        /// Identifier from Category.
        /// </summary>
        public int CategoryId { get; set; }

        [JsonIgnore]
        /// <summary>
        /// Identifier from Adress.
        /// </summary>
        public int? AddressId { get; set; }

        [JsonIgnore]
        /// <summary>
        /// Hotel categories.
        /// </summary>
        public CategoriesModel Category { get; set; }

        /// <summary>
        /// Hotel address.
        /// </summary>
        public AddressesModel? Address { get; set; }
    }
}
