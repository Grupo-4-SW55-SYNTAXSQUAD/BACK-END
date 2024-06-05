namespace peru_ventura_center.publishing.Domain.Model.Entities
{
    public class comunidad
    {
        public int ComunidadId { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string cultura { get; set; }

        public comunidad()
        {
            nombre = string.Empty;
            descripcion = string.Empty;
            cultura = string.Empty;
        }

        public comunidad(string name, string description, string culture)
        {
            nombre = name;
            descripcion = description;
            cultura = culture;
        }
    }
}
