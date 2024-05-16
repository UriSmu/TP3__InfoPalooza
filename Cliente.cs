public class Cliente
{
    public int DNI {get; private set;}
    public string Apellido {get; private set;}
    public string Nombre {get; private set;}
    public DateTime FechaDeInscripcion {get; set;}
    public int TipoEntrada {get; set;}
    public int Cantidad {get; set;}


    public Cliente() {}

    public Cliente(int dni, string apellido, string nombre, DateTime fecha, int tipo, int cantidad)
    {
        DNI = dni;
        Apellido = apellido;
        Nombre = nombre;
        FechaDeInscripcion = fecha;
        TipoEntrada = tipo;
        Cantidad = cantidad;
    }
}