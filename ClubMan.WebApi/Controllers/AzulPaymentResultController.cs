using ClubMan.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace ClubMan.WebApi.Controllers;

public class AzulPaymentResultController : Controller
{
    public IActionResult Approved(Cobro cobro)
    {
        return View(cobro);
    }
    
    public IActionResult Rejected(Cobro cobro)
    {
        return View(cobro);
    }
    public IActionResult Aborted(String errorMessage)
    {
        return View(errorMessage);
    }
}