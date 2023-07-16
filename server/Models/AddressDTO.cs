using System;
using System.Collections.Generic;

namespace server.Models;

public partial class AddressDTO
{
    public int ClientId { get; set; }

    public string? Country { get; set; }

    public string? StreetAddress { get; set; }

    public string? City { get; set; }

    public int? Zip { get; set; }

    public virtual Client? Client { get; set; } = null!;
}
