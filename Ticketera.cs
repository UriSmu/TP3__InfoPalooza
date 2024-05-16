public static class Ticketera
{
    private static Dictionary<int, Cliente> DicClientes = new Dictionary<int, Cliente>();
    private static int UltimoIdEntrada = 0;


    public static int DevolverUltimoID()
    {
        return UltimoIdEntrada;
    }

    public static int AgregarCliente(Cliente client)
    {
        UltimoIdEntrada++;
        DicClientes.Add(UltimoIdEntrada, client);
        return UltimoIdEntrada;
    }

    public static Cliente BuscarCliente(int id)
    {
        Cliente client = new Cliente();
        
        if(DicClientes.ContainsKey(id))
        {
            client = DicClientes[id];
        }
        else
        {
            client = null;
        }

        return client;
    }

    public static bool CambiarEntrada(int id, int tipo, int cantidad)
    {
        bool a = false;

        if(DicClientes.ContainsKey(id))
        {
            Cliente client = DicClientes[id];
            double importeAnterior = client.TipoEntrada * client.Cantidad;
            double importeNuevo = tipo * cantidad;
            if(importeNuevo > importeAnterior)
            {
                a = true;
                client.TipoEntrada = tipo;
                client.Cantidad = cantidad;
                DicClientes[id] = client;
            }
        }

        return a;
    }

    public static List<string> EstadisticasTicketera()
    {
        List<string> Estadisticas = new List<string>();

        if(DicClientes.Count() != 0)
        {
            //SE TOMA COMO CLIENTES PARA "INSCRIPTOS" Y "CANT. QUE COMPRO C/ ENTRADA", ÚNICAMENTE A LOS QUE INGRESAN SU DNI, NOMBRE Y APELLIDO (NO SE TOMA LA CANTIDAD DE ENTRADAS VENDIDAS)
            Estadisticas.Add("Cantidad de Clientes inscriptos: " + DicClientes.Count());
            
            int[] cantPorTipoClientes = new int[5]{0, 0, 0, 0, 0};
            int[] cantPorTipoTotal = new int[5]{0, 0, 0, 0, 0};
            int totalEntradas = 0;
            foreach (Cliente client in DicClientes.Values)
            {
                cantPorTipoClientes[client.TipoEntrada]++;
                cantPorTipoTotal[client.TipoEntrada]+= client.Cantidad;
                totalEntradas += client.Cantidad;
            }
            Estadisticas.Add("Cantidad de Clientes que compraron cada entrada - Tipo 1: " + cantPorTipoClientes[1] + " | Tipo 2: " + cantPorTipoClientes[2] + " | Tipo 3: " + cantPorTipoClientes[3] + " | Tipo 4: " + cantPorTipoClientes[4]);
            
            Estadisticas.Add("Porcentaje de cantidad de entradas vendidas diferenciadas por tipo de entrada respecto al total de entradas compradas - Tipo 1: " + (cantPorTipoTotal[1]/totalEntradas)*100 + "% | Tipo 2: " + (cantPorTipoTotal[2]/totalEntradas)*100 + "% | Tipo 3: " + (cantPorTipoTotal[3]/totalEntradas)*100 + "% | Tipo 4: " + (cantPorTipoTotal[4]/totalEntradas)*100 + "%");

            
            int[] valorCadaTipo = new int[5]{0, 45000, 60000, 30000, 100000};

            Estadisticas.Add("Recaudación de cada tipo - Tipo 1: $" + valorCadaTipo[1]*cantPorTipoTotal[1] + " | Tipo 2: $" + valorCadaTipo[2]*cantPorTipoTotal[2] + " | Tipo 3: $" + valorCadaTipo[3]*cantPorTipoTotal[3] + " | Tipo 4: $" + valorCadaTipo[4]*cantPorTipoTotal[4]);
            Estadisticas.Add("Recaudación total: " + (valorCadaTipo[1]*cantPorTipoTotal[1] + valorCadaTipo[2]*cantPorTipoTotal[2] + valorCadaTipo[3]*cantPorTipoTotal[3] + valorCadaTipo[4]*cantPorTipoTotal[4]));
        }

        return Estadisticas;

        //DEVUELVE LA LISTA "Estadisticas". SI "DicClientes" ESTÁ VACÍO, LA LISTA LO ESTARÁ TAMBIÉN, Y LUEGO EN EL MAIN DEVUELVE EL MENSAJE "Aún no se anotó nadie"
    } 
}