using System;
using System.Collections.Generic;

namespace SPV.Models;

public partial class Hrana
{
    public int IdHrane { get; set; }

    public string? SlikaHrane { get; set; }

    public string? ImeHrane { get; set; }

    public decimal? Cena { get; set; }

    public string? TipHrane { get; set; }

    public string? OpisHrane { get; set; }

    public virtual ICollection<HranaVsebujeAlergen> HranaVsebujeAlergens { get; } = new List<HranaVsebujeAlergen>();

    public virtual ICollection<Ponuja> Ponujas { get; } = new List<Ponuja>();
}
