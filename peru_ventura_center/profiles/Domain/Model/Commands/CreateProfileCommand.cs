namespace peru_ventura_center.profiles.Domain.Model.Commands
{
    public record CreateProfileCommand(string nombre, string correoElectronico, string contrasenia, string ubicacion);
 
}
