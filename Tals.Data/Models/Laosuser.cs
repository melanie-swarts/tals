﻿using System;
using System.Collections.Generic;

namespace Tals.Data.Models;

public partial class Laosuser
{
    public string? Email { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Role { get; set; }
}
