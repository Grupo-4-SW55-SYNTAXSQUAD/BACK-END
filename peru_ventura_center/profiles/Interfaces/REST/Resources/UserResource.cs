
namespace peru_ventura_center.profiles.Interfaces.REST.Resources
{
    public record UserResource(int UserId,string name, string email, string password, string phone, string userType);
}
