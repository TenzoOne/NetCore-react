using peliculasApi.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace peliculasApi.DTOs
{
    public class CrearGeneroDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 10)]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }
    }
}
