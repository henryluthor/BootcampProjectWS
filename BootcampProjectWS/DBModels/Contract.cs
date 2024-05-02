using System;
using System.Collections.Generic;

namespace BootcampProjectWS.DBModels;

public partial class Contract
{
    public int Contractid { get; set; }

    public byte[] Startdate { get; set; } = null!;

    public DateTime Enddate { get; set; }

    public int Serviceid { get; set; }

    public int Statuscontractid { get; set; }

    public int Clientid { get; set; }

    public int Methodpaymentid { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Methodpayment Methodpayment { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;

    public virtual Statuscontract Statuscontract { get; set; } = null!;
}
