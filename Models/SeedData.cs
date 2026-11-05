//para utilizar herramientas de Entity Framework Core. 
using Microsoft.EntityFrameworkCore;
//Para Obtener servicios que nuestra aplicacion tiene registros 
using Microsoft.Extensions.DependencyInjection;
//Para poder Utilizar MvcMovieContext y Movie
using MvcMovie.Data;
//Para utilizar herramientas como DateTime e IserviceProvider
using System;
//Para utlizar metodos como Any()
using System.Linq;


//SeedData es una clase que se encarga de introducir algunas pelicuals automaticamente para tener datos con los cuales podeamos trabajar

namespace MvcMovie.Models;//MvcMovie.Models: clases relacionadas con los modelos.

public static class SeedData
{
    //Una clase static no se puede instanciar con new.


    //Esta línea declara un método llamado Initialize.
    public static void Initialize(IServiceProvider serviceProvider)
    //IServiceProvider	Tipo del parámetro que recibe. Es una interfaz de .NET que permite obtener servicios que la app tiene registrados
    //serviceProvider	Nombre de la variable que recibe ese parámetro.
    //¿Qué es void? Significa que el método no devuelve ningún resultado.
    {
        using (var context = new MvcMovieContext(
            //Busca y obtiene las opciones de configuración de nuestro MvcMovieContext entre los servicios registrados.
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M
                },
                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Price = 3.99M
                },
                 new Movie
                 {
                     Title = "Encanto",
                     ReleaseDate = DateTime.Parse("2021-11-24"),
                     Genre = "Animation",
                     Price = 10.99M
                 },
                  new Movie
                  {
                      Title = "Coco",
                      ReleaseDate = DateTime.Parse("2017-11-22"),
                      Genre = "Animation",
                      Price = 9.99M
                  }
            );
            context.SaveChanges();
        }
    }
}