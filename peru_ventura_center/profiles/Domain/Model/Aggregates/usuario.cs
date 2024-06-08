using peru_ventura_center.profiles.Domain.Model.Commands;
using peru_ventura_center.profiles.Domain.Model.ValueObjects;

namespace peru_ventura_center.profiles.Domain.Model.Aggregates
{
    public class usuario
    {
        public int UsuarioId
        { get; set; }
        public string nombre
        { get; private set; }
        public EmailAddress CorreoElectronico
        { get; private set; }
        public string contrasenia
        { get; private set; }
        public string ubicacion
        { get; private set; }

        public string correoElectronico => CorreoElectronico.Address;

        public usuario()
        {
            nombre = string.Empty;
            CorreoElectronico = new EmailAddress();
            contrasenia = string.Empty;
            ubicacion = string.Empty;
        }

        public usuario(string nombre, string correoElectronico, string contrasenia, string ubicacion)
        {
            this.nombre = nombre;
            CorreoElectronico = new EmailAddress(correoElectronico);
            this.contrasenia = contrasenia;
            this.ubicacion = ubicacion;
        }

        public usuario(CreateProfileCommand command)
        {
            nombre = command.nombre;
            CorreoElectronico = new EmailAddress(command.correoElectronico);
            contrasenia = command.contrasenia;
            ubicacion = command.ubicacion;
        }
    }
}
