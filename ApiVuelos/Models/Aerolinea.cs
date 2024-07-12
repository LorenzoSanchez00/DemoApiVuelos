using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiVuelos.Models
{
    public class Aerolinea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAerolinea { get; set; }
        [Required(ErrorMessage = "Debe ingresar el Nombre de la Aerolinea")]
        public string? Nombre { get; set; }
    }
}
