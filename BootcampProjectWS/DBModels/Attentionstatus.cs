using System;
using System.Collections.Generic;

namespace BootcampProjectWS.DBModels;

public partial class Attentionstatus
{
    public int Attentionstatusid { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Attention> Attentions { get; set; } = new List<Attention>();
}
