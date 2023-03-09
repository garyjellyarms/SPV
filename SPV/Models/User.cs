using System;
using System.Collections.Generic;

namespace SPV.Models;

public partial class User
{
    public int IdUporabnika { get; set; }

    public string? UporabniskoIme { get; set; }

    public string? UporabniskoGeslo { get; set; }

    public string? ImeUporabnika { get; set; }

    public string? PriimekUporabnika { get; set; }

    public string? EmailUporabnika { get; set; }

    public DateTime? NastanekUporabnika { get; set; }

    public string? SaltUporabnika { get; set; }

    public virtual ICollection<Session> Sessions { get; } = new List<Session>();
}
