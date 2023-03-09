using System;
using System.Collections.Generic;

namespace SPV.Models;

public partial class Hrana
{
    public int IdHrane { get; set; }

    public string? SlikaHrane { get; set; }

    public string? ImeHrane { get; set; }

    public decimal? Cena { get; set; }

    public int FkRestevravije { get; set; }

    public int FkTipHrane { get; set; }

    public virtual Restevracija FkRestevravijeNavigation { get; set; } = null!;

    public virtual TipHrane FkTipHraneNavigation { get; set; } = null!;

    public virtual ICollection<HranaVsebujeAlergen> HranaVsebujeAlergens { get; } = new List<HranaVsebujeAlergen>();
}
