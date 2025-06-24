using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP05_Patejim_Feldman.Models;

namespace TP05_Patejim_Feldman.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Juego juego = new Juego();
        juego.Inicializar();
        HttpContext.Session.SetString("Juego", Objeto.ObjectToString(juego));
        return View("Index");
    }

    public IActionResult Registro(){
        Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("Juego"));
        HttpContext.Session.SetString("Juego", Objeto.ObjectToString(juego));
        return View("Registro");
    }
    
    public IActionResult Volver(){
        Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("Juego"));
        HttpContext.Session.SetString("Juego", Objeto.ObjectToString(juego));
        return View("Index");
    }

    public IActionResult Extra(){
        Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("Juego"));
        HttpContext.Session.SetString("Juego", Objeto.ObjectToString(juego));
        return View("Extra");
    }
    public IActionResult Tutorial(){
        Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("Juego"));
        HttpContext.Session.SetString("Juego", Objeto.ObjectToString(juego));
        return View("Tutorial");
    }
    public IActionResult Historia(){
        Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("Juego"));
        HttpContext.Session.SetString("Juego", Objeto.ObjectToString(juego));
        return View("Historia");
    }

    /* EMPIEZA EL JUEGO */

    public IActionResult Comienzo(string Nombre, string Id){
        Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("Juego"));
        HttpContext.Session.SetString("Juego", Objeto.ObjectToString(juego));
        return View("Sala1");
    }

    public IActionResult Respuesta(string respuesta){
        Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("Juego"));
        ViewBag.Vidas = juego.vidas;
        int result = juego.Respuesta(respuesta);
        HttpContext.Session.SetString("Juego", Objeto.ObjectToString(juego));
        if (result == 0){
            return View("Perdedor"); /* HACER LA VIEW DE PERDEDOR */
        }else if(result == 1){
            return View("VidaMenos");
        }
        switch(juego.habitacion){
            case 0: return View("Sala1");
            case 1: return View("Sala2");
            case 2: return View("Sala3");
            case 3: return View("Sala4");
        }
        return View();
    }
    /* HACER LA VIEW DE CUANDO PERDIO UNA VIDA */
    public IActionResult Reanudar(){
        Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("Juego"));
        HttpContext.Session.SetString("Juego", Objeto.ObjectToString(juego));
        switch(juego.habitacion){
            case 0: return View("Sala1");
            case 1: return View("Sala2");
            case 2: return View("Sala3");
            case 3: return View("Sala4");
        }
        return View();
    }
}
