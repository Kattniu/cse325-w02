using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
// ESTE ARCHIVO PREPARA LAS HERRAMIENTAS PARA TRABAJAR CON DB 
//ESte archivo NO MJUESTRA PELICULAS EN LA PANTALLA 
namespace MvcMovie.Data
{
    //CREAMOS CLASE MvcMovieContext QUE HEREDA DE DbContext, QUE ES LA CLASE BASE PARA EL CONTEXTO DE LA BASE DE DATOS EN Entity Framework Core. ESTA CLASE SE UTILIZA PARA CONFIGURAR Y ACCEDER A LA BASE DE DATOS PARA LA APLICACIÓN MVC MOVIE.
    public class MvcMovieContext : DbContext
    //: SIGNIFICA QUE NUESTRA CALASE HEREDA DE OTRA CLASE, EN ESTE CASO DE DbContext. DbContext ES LA CLASE BASE PARA EL CONTEXTO DE LA BASE DE DATOS EN Entity Framework Core. AL HEREDAR DE DbContext, MvcMovieContext PUEDE UTILIZAR TODAS LAS FUNCIONALIDADES DE DbContext PARA CONFIGURAR Y ACCEDER A LA BASE DE DATOS.
    //Pra no peerdernos Dbcontext uìes una clase proporcionada por Entity Framework Core 
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }
        //nos permite acceder a las peliculas guardadas en la base de datos. DbSet es una clase proporcionada por Entity Framework Core que representa una colección de entidades de un tipo específico (en este caso, Movie) que se pueden consultar y guardar en la base de datos. Al declarar una propiedad DbSet<Movie> llamada Movie, estamos indicando que queremos acceder a las películas guardadas en la base de datos a través de esta propiedad.
        public DbSet<MvcMovie.Models.Movie> Movie { get; set; } = default!;
    }
}
