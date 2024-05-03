using System;
using System.Collections.Generic;

namespace ProyectoTemporal.DBModels;

public partial class Payment
{
    public int Paymentid { get; set; }

    public byte[] Paymentdate { get; set; } = null!;

    public int Clientid { get; set; }

    public virtual Client Client { get; set; } = null!;
}
