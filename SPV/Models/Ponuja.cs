using System;
using System.Collections.Generic;

namespace SPV.Models;

public partial class Ponuja
{
    public int IdPonuja { get; set; }

    public int IdRestevravije { get; set; }

    public int IdHrane { get; set; }

    public string? TipHrane { get; set; }

    public string? SlikaTipHrane { get; set; }

    public virtual Restevracija IdRestevravijeNavigation { get; set; } = null!;
}
