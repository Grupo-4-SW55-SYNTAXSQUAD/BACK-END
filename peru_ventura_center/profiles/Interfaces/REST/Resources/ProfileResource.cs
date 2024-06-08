namespace peru_ventura_center.profiles.Interfaces.REST.Resources
{
    public record ProfileResource(int UsuarioId, string nombre, string correoElectronico, string contrasenia, string ubicacion);
}
