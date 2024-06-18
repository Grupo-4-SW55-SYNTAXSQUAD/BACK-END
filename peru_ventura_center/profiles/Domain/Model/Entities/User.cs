using peru_ventura_center.profiles.Domain.Model.Commands;

namespace peru_ventura_center.profiles.Domain.Model.Entities
{
    public partial class User
    {
        public int UserId { get; set; }
        public string name { get; private set; }
        public string email { get; private set; }
        public string password { get; private set; }
        public string phone { get; private set; }
        public string userType { get; set; }
        public User()
        {
            name = string.Empty;
            email = string.Empty;
            password = string.Empty;
            phone = string.Empty;
            userType = string.Empty;
        }
        public User(string name, string email, string password, string phone, string userType)
        {
            this.name = name;
            this.email = email;
            this.password = password;
            this.phone = phone;
            this.userType = userType;

        }
        public User(CreateUserCommand command)
        {
            name = command.name;
            email = command.email;
            password = command.password;
            phone = command.phone;
            userType = command.userType;
        }
    }
}
