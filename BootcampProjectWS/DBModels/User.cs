using System;
using System.Collections.Generic;

namespace BootcampProjectWS.DBModels;

public partial class User
{
    public int Userid { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Rolid { get; set; }

    public byte[] Creationdate { get; set; } = null!;

    public int? Usercreate { get; set; }

    public int? Userapproval { get; set; }

    public int Statusid { get; set; }

    public virtual Rol Rol { get; set; } = null!;

    public virtual Userstatus Status { get; set; } = null!;

    public virtual ICollection<Cash> Cashes { get; set; } = new List<Cash>();
}
