namespace peru_ventura_center.publishing.Domain.Model.Entities
{
    public class Promotion
    {
        public int idPromocion { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime horaInicio { get; set; }
        public string ubicacion { get; set; }
        public string oferta { get; set; }
        public decimal precio { get; set; }

        public Promotion()
        {
            nombre = string.Empty;
            descripcion = string.Empty;
            horaInicio = DateTime.Now;
            ubicacion = string.Empty;
            oferta = string.Empty;
            precio = 0;

        }

        public Promotion(string nombre, string descripcion, string ubicacion, DateTime horaInicio, string oferta, decimal precio)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.ubicacion = ubicacion;
            this.horaInicio = horaInicio;
            this.oferta = oferta;
            this.precio = precio;
        }
    }
}
