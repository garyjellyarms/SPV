using System;
using System.Collections.Generic;

namespace SPV.Models;

public partial class HranaVsebujeAlergen
{
    public int IdHranaVsebujeAlergen { get; set; }

    public int FkHrane { get; set; }

    public int FkAlergen { get; set; }

    public virtual Alergen FkAlergenNavigation { get; set; } = null!;

    public virtual Hrana FkHraneNavigation { get; set; } = null!;
}
