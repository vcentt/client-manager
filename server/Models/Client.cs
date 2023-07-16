using System;
using System.Collections.Generic;

namespace server.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public virtual Address? Address { get; set; }

    public virtual Profile? Profile { get; set; }
}
