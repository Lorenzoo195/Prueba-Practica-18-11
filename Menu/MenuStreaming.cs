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

            Console.WriteLine("\n----Menu Streaming-----");
            Console.WriteLine("------1. Ver Catalogo----");
            Console.WriteLine("------2. Busca por titulo----");
            Console.WriteLine("------3. Buscar Peliculas----");
            Console.WriteLine("------0. Salir-----------");
            Console.WriteLine("Selecciona una opción:");



            if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 0 || opcion > 6)
            {
                Console.WriteLine("Error: selecciona una opción válida (0-6).");
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
}