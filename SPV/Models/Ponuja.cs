using System;
using System.Collections.Generic;

namespace SPV.Models;

public partial class Ponuja
{
    public int IdVsebuje { get; set; }

    public int FkIdRestevravije { get; set; }

    public int FkIdHrane { get; set; }

    public virtual Hrana FkIdHraneNavigation { get; set; } = null!;

    public virtual Restevracija FkIdRestevravijeNavigation { get; set; } = null!;
}
