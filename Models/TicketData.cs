using System;

namespace TicketValidationSite.Models;

public class TicketData
{
    public int Cuenta { get; set; }
    public string RazonSocial { get; set; } = default!;
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }
    public string Folio { get; set; } = default!;
    public string Hash { get; set; } = default!;
    public string Hash2 { get; set; } = default!;
}
