﻿using System;
using System.Collections.Generic;

namespace SPV.Models;

public partial class Restevracija
{
    public int IdRestevravije { get; set; }

    public string? ImeRestevracije { get; set; }

    public double? XKordinata { get; set; }

    public double? YKordinata { get; set; }

    public TimeSpan? OdprtoOd { get; set; }

    public TimeSpan? OdprtoDo { get; set; }

    public double? Ocena { get; set; }

    public virtual ICollection<Ponuja> Ponujas { get; } = new List<Ponuja>();
}
