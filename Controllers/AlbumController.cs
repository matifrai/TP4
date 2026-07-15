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
        ViewBag.Sobre = sobre;
        return View("Sobres");
    }

    public IActionResult Album(){
        ViewBag.Jugadores = bd.obtenerTodos();
        ViewBag.Figuritas = bd.obtenerFiguritasUsuario();

        return View();
    }

    [HttpPost]
    public IActionResult PegarFigurita(int IdJugador){
        bd.pegarFiguritas(IdJugador);
        return RedirectToAction("Album");
    }








}