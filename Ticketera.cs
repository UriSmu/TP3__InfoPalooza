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
        
    }
}