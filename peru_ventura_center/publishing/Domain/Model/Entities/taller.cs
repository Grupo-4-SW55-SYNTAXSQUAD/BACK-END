namespace peru_ventura_center.publishing.Domain.Model.Entities
{
    public class Taller
    {
        public int TallerId { get; set; }
        //public int IdPrecioTaller { get; set; }
      //  public int IdCommunity { get; set; }
       // public int IdUsuario { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string ubicacion { get; set; }
        public string horario { get; set; }
        public int cupoMaximo { get; set; }
        public string medidaSeguridad { get; set; }

        public Taller() {
            nombre = string.Empty;
            descripcion = string.Empty;
            ubicacion = string.Empty;
            horario = string.Empty;
            cupoMaximo = 0;
            medidaSeguridad = string.Empty;
        }

        public Taller(string name, string description, string location, string schedule, int maxCapacity, string securityMeasures)
        {
            // IdPrecioTaller = idPrecioTaller;
            // IdCommunity = idCommunity;
            // IdUsuario = idUsuario;
            nombre = name;
            descripcion = description;
            ubicacion = location;
            horario = schedule;
            cupoMaximo = maxCapacity;
            medidaSeguridad = securityMeasures;
        }

    }
}
