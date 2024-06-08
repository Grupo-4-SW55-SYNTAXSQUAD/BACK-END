using peru_ventura_center.profiles.Domain.Model.ValueObjects;

namespace peru_ventura_center.profiles.Domain.Model.Queries
{
    public record GetProfileByEmailQuery(EmailAddress Email);
}
