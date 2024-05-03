﻿using System;
using System.Collections.Generic;

namespace ProyectoTemporal.DBModels;

public partial class Attentiontype
{
    public int Attentiontypeid { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Attention> Attentions { get; set; } = new List<Attention>();
}
