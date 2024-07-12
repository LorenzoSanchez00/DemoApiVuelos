using System.ComponentModel.DataAnnotations;

namespace ApiVuelos.DTOs
{
    public class ModificarVueloDto
    {
        public int IdVuelo { get; set; }
        public int IdAerolinea { get; set; }
        public string? Origen { get; set; }
        public string? Destino { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FechaIda { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FechaVuelta { get; set; }
        public string? Clase { get; set; }
        public decimal Precio { get; set; }
    }
}
