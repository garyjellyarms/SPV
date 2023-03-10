using System;
using System.Collections.Generic;

namespace SPV.Models;

public partial class Alergen
{
    public int IdAlergen { get; set; }

    public string? Snov { get; set; }

    public string? StAlergena { get; set; }

    public virtual ICollection<HranaVsebujeAlergen> HranaVsebujeAlergens { get; } = new List<HranaVsebujeAlergen>();
}
