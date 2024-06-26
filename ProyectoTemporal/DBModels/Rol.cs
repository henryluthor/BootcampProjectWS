﻿using System;
using System.Collections.Generic;

namespace ProyectoTemporal.DBModels;

public partial class Rol
{
    public int Rolid { get; set; }

    public string Rolname { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
