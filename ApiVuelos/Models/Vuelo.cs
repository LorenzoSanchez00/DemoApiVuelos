using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiVuelos.Models
{
    public class Vuelo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVuelo { get; set; }
        [Required(ErrorMessage = "Debe ingresar el id de la Aerolinea.")]
        public int IdAerolinea { get; set; }
        [Required(ErrorMessage = "Debe ingresar el origen del vuelo.")]
        public string? Origen {  get; set; }
        [Required(ErrorMessage = "Debe ingresar el destino del vuelo.")]
        public string? Destino { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FechaIda { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FechaVuelta { get; set; }
        public string? Clase { get; set; }
        [Required(ErrorMessage = "Debe ingresar el valor del vuelo.")]
        public decimal Precio { get; set; }

        [ForeignKey("IdAerolinea")]
        public virtual Aerolinea? Aerolinea { get; set;}
    }
}
