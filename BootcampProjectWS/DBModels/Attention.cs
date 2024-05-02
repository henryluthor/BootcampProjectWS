using System;
using System.Collections.Generic;

namespace BootcampProjectWS.DBModels;

public partial class Attention
{
    public int Attentionid { get; set; }

    public int Turnid { get; set; }

    public int Clientid { get; set; }

    public int Attentiontypeid { get; set; }

    public int Attentionstatusid { get; set; }

    public virtual Attentionstatus Attentionstatus { get; set; } = null!;

    public virtual Attentiontype Attentiontype { get; set; } = null!;

    public virtual Client Client { get; set; } = null!;

    public virtual Turn Turn { get; set; } = null!;
}
