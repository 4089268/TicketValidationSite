using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Mvc;
using TicketValidationSite.Models;

namespace TicketValidationSite.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Route("/qr")]
    public IActionResult Index(
        [FromQuery] string n,
        [FromQuery] string c,
        [FromQuery] string f,
        [FromQuery] string t,
        [FromQuery] string h,
        [FromQuery] string? i
    )
    {
        System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("es-MX");
        System.Globalization.CultureInfo.CurrentUICulture = new System.Globalization.CultureInfo("es-MX");
        
        try
        {
            var model = new TicketData();
            model.RazonSocial = n;
            model.Cuenta = int.Parse(c);
            model.Fecha = DateTime.TryParseExact(f, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out DateTime d) ? d : throw new ArgumentException("La fecha tiene un formato invalido");
            model.Total = decimal.Parse(t);
            model.Folio = i ?? "";
            model.Hash = h;
            model.Hash2 = h;

            // Concatenate the data to hash
            var dataToHash = $"{n}{c}{f}{t}{i}*SICEM*";

            // Compute SHA256 hash
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(dataToHash);
                var hashBytes = sha256.ComputeHash(bytes);
                model.Hash2 = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
            return View(model);
        }
        catch (System.Exception)
        {
            return View("IndexError");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
