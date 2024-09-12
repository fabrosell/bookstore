using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Client.Models
{
    public class Book
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Id { get; set; }
        [Required(ErrorMessage = "Ingrese Título del Libro")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Entre 3 y 500 caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ingrese Año del Libro")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Ingrese Género del Libro")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Entre 3 y 50 caracteres")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Ingrese cantidad de Páginas del Libro")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Cantidad de páginas inválida")]
        public int Pages { get; set; }
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Ingrese RUT del Autor")]
        [Range(100000, Int32.MaxValue, ErrorMessage = "RUT inválido")]
        public int Author_RUT { get; set; }
        [Required(ErrorMessage = "Ingrese DV de Rut del Autor")]
        public char Autor_RUT_DV { get; set; }
        public string? Author_FullName { get; set; }
    }
}
