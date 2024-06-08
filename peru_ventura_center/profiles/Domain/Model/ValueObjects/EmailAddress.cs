namespace peru_ventura_center.profiles.Domain.Model.ValueObjects
{
    public record EmailAddress(string Address)
    {
        public EmailAddress() : this(string.Empty)
        {

        }
    }
}
