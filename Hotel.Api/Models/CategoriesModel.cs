using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Hotel.Api.Models
{
    /// <summary>
    /// Class that represents the Category entity.
    /// </summary>
    public class CategoriesModel
    {
        [Key]
        /// <summary>
        /// Category Identifier.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Category Name.
        /// </summary>
        public string? Name { get; set; }

        [JsonIgnore]
        /// <summary>
        /// List of hotels belonging to the category.
        /// </summary>
        public List<HotelsModel>? Hotels { get; set; }
    }
}
