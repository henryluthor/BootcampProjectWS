using System;
using System.Collections.Generic;

namespace BootcampProjectWS.DBModels;

public partial class Client
{
    public int Clientid { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Identification { get; set; } = null!;

    public string Phonenumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? Referenceaddress { get; set; }

    public string Email { get; set; } = null!;

    public virtual ICollection<Attention> Attentions { get; set; } = new List<Attention>();

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
