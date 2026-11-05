using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
//ESTE ARCHIVO NO DISEÑA LA PAGINA 
//ESTE ARCHIVO UTILIZA ESAS HERRAMIENTAS (MvcMovieContext.cs) PARA HACER COSAS for example: get put post and delete  
namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        //AQUI DECLARAMOS UNA VARIABLE LLAMADA _context DE TIPO MvcMovieContext, QUE ES LA CLASE QUE REPRESENTA EL CONTEXTO DE LA BASE DE DATOS PARA LA APLICACIÓN MVC MOVIE. ESTA VARIABLE SE UTILIZA PARA ACCEDER A LOS DATOS DE LA BASE DE DATOS Y REALIZAR OPERACIONES CRUD (CREAR, LEER, ACTUALIZAR, ELIMINAR) SOBRE LA ENTIDAD Movie.
        private readonly MvcMovieContext _context;
        //traduccion: Voy a tener una variable llamada _context que guardara un objeto de tipo MvcMovieContext, que es la clase que representa el contexto de la base de datos para la aplicación MVC Movie. Esta variable se utiliza para acceder a los datos de la base de datos y realizar operaciones CRUD (crear, leer, actualizar, eliminar) sobre la entidad Movie.
        public MoviesController(MvcMovieContext context)

        {

            _context = context;
        }

        // GET: Movies
        //este archivo decide que hacer con las solicitudes que vienen del navegador, y luego decide que vista mostrar al usuario.
        // Metodo Publico que puede ser accesible desde afuera de la clase
        //ESTE METODO : pide todas las peliculas a la base de datos,  recibe los resultados y los envia a la vista Index 
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie.ToListAsync());
        }


        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie != null)
            {
                _context.Movie.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
