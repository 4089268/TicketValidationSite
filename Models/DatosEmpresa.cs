using System;

namespace TicketValidationSite.Models;

public class DatosEmpresa
{
    public string RazonSocial { get; set; } = "COMISION DEL AGUA DEL ESTADO DE VERACRUZ";
    public string Direccion1 { get; set; } = "ABASOLO S/N, COL. CENTRO";
    public string Direccion2 { get; set; } = "CP. 95641, CD ISLA VERACRUZ";
    public string? RFC { get; set; }
    public string? Telefono { get; set; }

}
