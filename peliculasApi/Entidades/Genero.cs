using peliculasApi.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace peliculasApi.Entidades
{
    public class Genero
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 10)]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }

    }
}
