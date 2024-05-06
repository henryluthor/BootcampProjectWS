using System;
using System.Collections.Generic;

namespace BootcampProjectWS.DBModels;

public partial class Rol
{
    public int Rolid { get; set; }

    public string Rolname { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
