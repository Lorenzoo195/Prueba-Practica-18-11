using Streaming;
namespace Menu;

public class MenuStreaming
{
    private List<Contenido> catalogo;
    
    public void Iniciar()
    {
        catalogo = GenerarCatalogo();
        int opcion = 0;
        do
        {

            Console.WriteLine("\n---Streaming----------------------");
            Console.WriteLine("-----1. Ver todos los contenidos----");
            Console.WriteLine("-----2. Busca contenido-------------");
            Console.WriteLine("-----3. Mostrar peliculas-----------");
            Console.WriteLine("-----4. Filtrar duracion------------");
            Console.WriteLine("-----5. Ver Estadisticas------------");
            Console.WriteLine("-----0. Salir-----------------------");
            Console.WriteLine("Selecciona una opción:");



            if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 0 || opcion > 5)
            {
                Console.WriteLine("Error: selecciona una opción válida (0-5).");
                continue;
            }
            switch (opcion)
            {
                case 1:
                    MostrarCatalogo();
                    break;

                case 2:
                    BuscarPorTitulo();
                    break;

                case 3:
                    BuscarPeliculas();
                    break;

                case 4:
                    BuscarPorDuracion();
                    break;

                case 5:
                    Estadisticas();
                    break;

                case 0:
                    Console.WriteLine("¡Hasta pronto!");
                    break;
            }
        } while (opcion != 0);
    }

    public List<Contenido> GenerarCatalogo()
    {
        return new List<Contenido>
        {
            new Pelicula("El Padrino", 175, "Francis Ford Coppola"),
            new Pelicula("Interstellar", 169, "Christopher Nolan"),
            new Serie("Breaking Bad", 47, 5),
            new Serie("Stranger Things", 50, 4),
            new Documental("Planeta Tierra", 60, "Naturaleza")
        };
    }
    public void MostrarCatalogo()
    {

        foreach (Contenido c in catalogo)
        {
            Console.WriteLine(c.ObtenerDescripcion());
        }
    }

    public void BuscarPorTitulo()
    {
        Console.Write("\nDime el titulo de lo que quieres buscar: ");
        string textoBusqueda = Console.ReadLine().ToLower();
        bool encontrado = false;
        foreach(Contenido c in catalogo)
        {
            if (c.Titulo.ToLower().Contains(textoBusqueda))
            {
                Console.WriteLine("\nContenido encontrado:");
                Console.WriteLine($"{c.Titulo} - {c.Duracion} minutos");
                encontrado = true;
            }
        }
        if (!encontrado)
        {
            Console.WriteLine("\nNo se ha encontrado ningún contenido con ese título.");
        }
    }

    public void BuscarPeliculas()
    {
        foreach (Contenido c in catalogo)
        {
            if (c is Pelicula)
            {
                Console.WriteLine(c.ObtenerDescripcion());
            }
        }
    }
    public void BuscarPorDuracion()
    {
        Console.WriteLine("Dame una duracion maxima de un contenido");
       if(int.TryParse(Console.ReadLine(), out int duracionMax))
        {
            foreach(Contenido c in catalogo)
            {
                if(c.Duracion <= duracionMax)
                {
                    Console.WriteLine(c.ObtenerDescripcion());
                }
            }
        } else
        {
            Console.WriteLine("No hay coincidencia");
        }
    }

    public void Estadisticas()
    {
        int contPelicula = 0;
        int contSerie = 0;
        int contDocumental = 0;
        int total = 0;
        foreach(Contenido c in catalogo)
        {
            total++;
            if (c is Pelicula)
            {
                contPelicula++;
            }
            if (c is Serie)
            {
                contSerie++;
            }
            if (c is Documental)
            {
                contDocumental++;
            }
         }
            Console.WriteLine("\n===Estadisticas===");
            Console.WriteLine($"Total Contenidos: {total}");
            Console.WriteLine($"Peliculas: {contPelicula}");
            Console.WriteLine($"Series: {contSerie}");
            Console.WriteLine($"Documentales: {contDocumental}");
    }
}