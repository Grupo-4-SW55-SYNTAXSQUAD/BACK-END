
namespace peru_ventura_center.profiles.Interfaces.REST.Resources
{
    public record CreateUserResource(string name, string email, string password, string phone,string userType);
}
