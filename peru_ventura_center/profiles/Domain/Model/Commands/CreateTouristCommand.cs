namespace peru_ventura_center.profiles.Domain.Model.Commands
{
    public record CreateTouristCommand(int UserId, int? ReviewId, int? BookingId);

}
