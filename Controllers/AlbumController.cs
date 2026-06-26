using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP4.Models;

namespace TP4.Controllers;

public class AlbumController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}