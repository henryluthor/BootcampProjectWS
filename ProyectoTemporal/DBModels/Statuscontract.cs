﻿using System;
using System.Collections.Generic;

namespace ProyectoTemporal.DBModels;

public partial class Statuscontract
{
    public int Statuscontractid { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
