
namespace peru_ventura_center.profiles.Domain.Model.Commands
{
    public record CreateUserCommand(string name, string email, string password, string phone, string userType);
   
}
