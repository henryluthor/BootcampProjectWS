using System;
using System.Collections.Generic;

namespace BootcampProjectWS.DBModels;

public partial class Userstatus
{
    public int Statusid { get; set; }

    public string Description { get; set; } = null!;
}
