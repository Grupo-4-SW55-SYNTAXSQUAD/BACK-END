using peru_ventura_center.publishing.Domain.Model.Entities;

namespace peru_ventura_center.publishing.Domain.Model.Aggregates
{
    public class promociones
    {
        public int PromocionId { get; set; }
        public comunidad Comunidad { get; set; }
        public int ComunidadId { get; set; }
        public Taller Taller { get; set; }
        public int TallerId { get; set; }

        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string horaInicio { get; set; }
        public string ubicacion { get; set; }
        public string oferta { get; set; }
        public decimal precio { get; set; }

        public promociones(string nombre, string descripcion, int ComunidadId, int TallerId, string ubicacion, string horaInicio, string oferta, decimal precio)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.ComunidadId = ComunidadId;
            this.TallerId = TallerId;
            this.ubicacion = ubicacion;
            this.horaInicio = horaInicio;
            this.oferta = oferta;
            this.precio = precio;
        }
    }
}
