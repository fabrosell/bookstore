using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bookstore.Client.Models
{
    public class Author
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Ingrese RUT del autor")]
        [Range(100000, Int32.MaxValue, ErrorMessage = "RUT inválido")]        
        public int? RUT { get; set; }

        [Required(ErrorMessage = "Ingrese DV de RUT")]
        public char? DV { get; set; }

        [Required(ErrorMessage = "Ingrese nombre del Autor")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Entre 3 y 200 caracteres")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Ingrese fecha de nacimiento del Autor")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage ="Ingrese una fecha de nacimiento válida")]
        public DateTime? BirthDate { get; set; }

        public string? City { get; set; }

        [Required(ErrorMessage = "Ingrese email del Autor")]
        [EmailAddress(ErrorMessage = "Ingrese un email válido para Autor")]
        public string? eMail { get; set; }
    }
}
