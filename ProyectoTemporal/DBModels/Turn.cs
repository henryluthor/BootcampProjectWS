using System;
using System.Collections.Generic;

namespace ProyectoTemporal.DBModels;

public partial class Turn
{
    public int Turnid { get; set; }

    public string Description { get; set; } = null!;

    public byte[] Date { get; set; } = null!;

    public int Cashid { get; set; }

    public int Usergestorid { get; set; }

    public virtual Attention? Attention { get; set; }

    public virtual Cash Cash { get; set; } = null!;
}
