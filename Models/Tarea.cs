namespace models;
public enum Estados{
    ToDo,
    Doing,
    Review,
    Done
}
public class Tarea{
    private int Id;
    private int Id_tablero;
    private string Nombre;
    private Estados Estado;
    private string? Descripcion;
    private string Color;
    private int Id_usuario_Asignado;
}