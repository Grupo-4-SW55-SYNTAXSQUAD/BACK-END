using peru_ventura_center.profiles.Domain.Model.Aggregates;

namespace peru_ventura_center.publishing.Domain.Model.Entities
{
    public class Taller
    {
        public int TallerId { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string ubicacion { get; set; }
        public string horario { get; set; }
        public int cupoMaximo { get; set; }
        public string medidaSeguridad { get; set; }
        public comunidad Comunidad { get; set; }
        public int ComunidadId { get; set; }
        public usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public Taller() {
            nombre = string.Empty;
            descripcion = string.Empty;
            ubicacion = string.Empty;
            horario = string.Empty;
            cupoMaximo = 0;
            medidaSeguridad = string.Empty;
        }

        public Taller(string name, string description, string location, string schedule, int maxCapacity, string securityMeasures, int ComunidadId, int UsuarioId)
        {
            
            nombre = name;
            descripcion = description;
            ubicacion = location;
            horario = schedule;
            cupoMaximo = maxCapacity;
            medidaSeguridad = securityMeasures;
            this.ComunidadId = ComunidadId;
            this.UsuarioId = UsuarioId;
        }

    }
}
