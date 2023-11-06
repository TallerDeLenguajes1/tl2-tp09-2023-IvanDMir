using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
namespace repositorios{
    public class TableroRepositorios{

         private string cadenaConexion = "Data Source=DB/Tareas.db;Cache=Shared";

          public void Crear(Tablero tablero){
         var query = $"INSERT INTO Tablero (nombre,descripcion,id_usuario_propietario) VALUES (@nombre,@desc,@idUsuario) WHERE id_Tablero = @Id_Tablero";
         using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
            connection.Open();

            var command = new SQLiteCommand(query, connection);

            command.Parameters.Add(new SQLiteParameter("@nombre", tablero.Nombre));
            command.Parameters.Add(new SQLiteParameter("@desc", tablero.Descripcion));
            command.Parameters.Add(new SQLiteParameter("@idUsuario", tablero.IdUsuarioPropietario));
            
            command.ExecuteNonQuery();
            connection.Close();
         }
          }
         public List<Tablero>  GetAll(){
             {
            var queryString = @"SELECT * FROM Tablero;";
            List<Tablero> Tableros = new List<Tablero>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection);
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tablero = new Tablero();
                        tablero.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                        tablero.Nombre = reader["nombre"].ToString();
                        tablero.Descripcion = reader["descripcion"].ToString();
                        tablero.IdUsuarioPropietario =Convert.ToInt32(reader["id_usuario_propietario"]);
                        Tableros.Add(tablero);
                    }
                }
                connection.Close();
            }
            return Tableros;
        }
        }

    }
}

