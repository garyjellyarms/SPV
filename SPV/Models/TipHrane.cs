using System;
using System.Collections.Generic;

namespace SPV.Models;

public partial class TipHrane
{
    public int IdTipHrane { get; set; }

    public string? ImeTipa { get; set; }

    public string? SlikaTipa { get; set; }

    public virtual ICollection<Hrana> Hranas { get; } = new List<Hrana>();
}
