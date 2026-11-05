//indicamos a c# que queremos utilizar funcionalidades de asp.net core MVC 
using Microsoft.AspNetCore.Mvc;
//POR EJEMPLO gracias a esta biblioteca podemos crear controladores y vistas para nuestra aplicación web.

//Permite utilizar herramientas para codificar texto de manera segura al trabajar con contenido web 
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;

public class HelloWorldController : Controller
{
    // 
    // GET: /HelloWorld/

    public IActionResult Index()
    // IActionResult indica que el metodo devuelve un resultado de una accion web 
    {
        return View();
    }
    // 
    // GET: /HelloWorld/Welcome/ 

    //recordemos que IactionResult es una interfaz que representa el resultado de una acción en un controlador de ASP.NET Core MVC.
    //en este caso una vista que se renderiza como respuesta a una solicitud HTTP.
    public IActionResult Welcome(string name, int numTimes = 1)
    //numtimes recibe cuantas veces repetir el mensaje 
    {
        //ViewData diccionario que permite pasar datos del controller a la view 
        ViewData["Message"] = "Hello " + name; //["Message"] es la clave con la que identificamos el dato 
        ViewData["NumTimes"] = numTimes; //contiene el numero recibido desde la URL 

        return View(); //devuelve la vista correspondiente a la acción Welcome, que se encuentra en la carpeta Views/HelloWorld/Welcome.cshtml.
    }


    //public string Welcome(string name, int numTimes = 1)
    //{
    //htmlencode es una función que codifica caracteres especiales en HTML para evitar problemas de seguridad como la inyección de código malicioso.
    //Default es una propiedad que devuelve una instancia predeterminada del codificador HTML, que se puede utilizar para codificar texto de manera segura.
    //Encode es un método que toma una cadena de texto y la codifica en formato HTML, reemplazando caracteres especiales con sus entidades HTML correspondientes.

    //    return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
    //}
}