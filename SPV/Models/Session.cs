using System;
using System.Collections.Generic;

namespace SPV.Models;

public partial class Session
{
    public int IdSession { get; set; }

    public int FkUporabnika { get; set; }

    public DateTime? DateTo { get; set; }

    public virtual User FkUporabnikaNavigation { get; set; } = null!;
}
