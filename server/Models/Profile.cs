namespace server.Models;

public partial class Profile
{
    public int ClientId { get; set; }

    public byte? Age { get; set; }

    public string? Gender { get; set; }

    public string? MaritalStatus { get; set; }

    // public virtual Client? Client { get; set; } = null!;
}
