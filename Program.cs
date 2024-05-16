namespace TP3__InfoPalooza;

class Program
{
    static void Main(string[] args)
    {
        int eleccion = -1;
        bool esEntero = false;

        do
        {
            Console.WriteLine("1. Nueva Inscripción");
            Console.WriteLine("2. Obtener Estadísticas del Evento");
            Console.WriteLine("3. Buscar Cliente");
            Console.WriteLine("4. Cambiar entrada de un Cliente");
            Console.WriteLine("5. Salir");
            while (!esEntero || eleccion < 1 || eleccion > 5)
            {
                esEntero = int.TryParse(Console.ReadLine(), out eleccion);
            }

            switch (eleccion)
            {
                case 1:
                    NuevaInscripcion();
                    break;
                
                case 2:
                    ObtenerEstadisticas();
                    break;
                
                case 3:
                    BuscarCliente();
                    break;

                case 4:
                    CambiarEntrada();
                    break;
            }

            if (eleccion != 5) eleccion = -1;
        }while(eleccion != 5);

    }


    static void NuevaInscripcion()
    {
        bool esInt = false, esVacio = true;
        int dni, tipo, cantidad;
        string nombre, apellido;

        do
        {
            Console.WriteLine("Ingrese su nombre");
            nombre = Console.ReadLine();
            if(nombre != "") esVacio = false;
        }while(esVacio);

        esVacio = true;
        do
        {
            Console.WriteLine("Ingrese su apellido");
            apellido = Console.ReadLine();
            if(apellido != "") esVacio = false;
        }while(esVacio);

        do
        {
            Console.WriteLine("Ingrese su DNI");
            esInt = int.TryParse(Console.ReadLine(), out dni);
        }while(!esInt);

        esInt = false;
        do
        {
            Console.WriteLine("Ingrese el tipo de entrada que quiere:");
            Console.WriteLine("1. Día 1 , valor a abonar $45000");
            Console.WriteLine("2. Día 2, valor a abonar $60000");
            Console.WriteLine("3. Día 3, valor a abonar $30000");
            Console.WriteLine("4. Full Pass, valor a abonar $100000");
            esInt = int.TryParse(Console.ReadLine(), out tipo);
        }while(!esInt && (tipo < 1 && tipo > 4));

        esInt = false;
        do
        {
            Console.WriteLine("Ingrese la cantidad que desea");
            esInt = int.TryParse(Console.ReadLine(), out cantidad);
        }while(!esInt);

        Cliente cliente = new Cliente(dni, nombre, apellido, DateTime.Today, tipo, cantidad);

        Ticketera.AgregarCliente(cliente);
    }

    static void ObtenerEstadisticas()
    {
        List<string> Estadisticas = Ticketera.EstadisticasTicketera();

        if(Estadisticas.Count() != 0)
        {
            foreach(string cadena in Estadisticas)
            {
                Console.WriteLine(cadena);
            }
        }
        else
        {
            Console.WriteLine("Aún no se anotó nadie");
        }
    }

    static void BuscarCliente()
    {
        bool esInt = false;
        int id;

        do
        {
            Console.WriteLine("Ingrese el ID");
            esInt = int.TryParse(Console.ReadLine(), out id);
        }while(!esInt);

        Cliente cliente = Ticketera.BuscarCliente(id);

        if(cliente != null)
        {
            Console.WriteLine("Nombre: " + cliente.Nombre);
            Console.WriteLine("Apellido: " + cliente.Apellido);
            Console.WriteLine("DNI: " + cliente.DNI);
            Console.WriteLine("Fecha de Inscripcion: " + cliente.FechaDeInscripcion);
            Console.WriteLine("Tipo de Entrada: " + cliente.TipoEntrada);
            Console.WriteLine("Cantidad: " + cliente.Cantidad);
        }

        else
        {
            Console.WriteLine("No existe un cliente con ID #" + id);
        }
    }

    static void CambiarEntrada()
    {
        bool esInt = false;
        int id, tipo, cantidad;

        do
        {
            Console.WriteLine("Ingrese el ID");
            esInt = int.TryParse(Console.ReadLine(), out id);
        }while(!esInt);

        esInt = false;
        do
        {
            Console.WriteLine("Ingrese el tipo de entrada que quiere:");
            Console.WriteLine("1. Día 1 , valor a abonar $45000");
            Console.WriteLine("2. Día 2, valor a abonar $60000");
            Console.WriteLine("3. Día 3, valor a abonar $30000");
            Console.WriteLine("4. Full Pass, valor a abonar $100000");
            esInt = int.TryParse(Console.ReadLine(), out tipo);
        }while(!esInt && (tipo < 1 && tipo > 4));

        esInt = false;
        do
        {
            Console.WriteLine("Ingrese la cantidad que desea");
            esInt = int.TryParse(Console.ReadLine(), out cantidad);
        }while(!esInt);

        bool sePuedeCambiar = Ticketera.CambiarEntrada(id, tipo, cantidad);

        if(sePuedeCambiar) Console.WriteLine("Se ha cambiado la compra");
        else Console.WriteLine("No se pude cambiar la compra a una de menor valor");
    }
}
