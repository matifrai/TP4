using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP4.Models;

namespace TP4.Controllers;

public class AlbumController : Controller
{
    private BD bd = new BD();

    public IActionResult Index(){
        return View();
    } 
    public IActionResult Sobres(){
        return View();
    }

    [HttpPost]
    public IActionResult AbrirSobre(){
        List<Jugadores> sobre = bd.obtenerCincoRandom();
        foreach (Jugadores jugador in sobre){
            bd.guardarFigurita(jugador.Id);
        }
        return View("Sobres", sobre);
    }

    public IActionResult Album(){
        return View();
    }








}