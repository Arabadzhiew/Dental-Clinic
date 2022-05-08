using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dental_Clinic.Models;
using Dental_Clinic.Repositories;
using Dental_Clinic.Repositories.Impl;

namespace Dental_Clinic.Controllers;

public class HomeController : Controller
{
    
    public IActionResult Index()
    {
        return View();
    }

}
