using System;
using System.Collections.Generic;

namespace ProyectoTemporal.DBModels;

public partial class Service
{
    public int Serviceid { get; set; }

    public string Servicename { get; set; } = null!;

    public string Servicedescription { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();
}
