namespace peru_ventura_center.Profiles.Interfaces.REST.Resources
{
    public record PatchUserResource(string? name, string? email, string? phone,string? password);
}
