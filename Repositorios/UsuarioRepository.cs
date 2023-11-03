
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace repositorios{
    public class UsuarioRepositorio{
        private string cadenaConexion = "Data Source=DB/Tareas.db;Cache=Shared";

        public List<Usuario>  GetAll(){
             {
            var queryString = @"SELECT * FROM usuario;";
            List<Usuario> Usuarios = new List<Usuario>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection);
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Usuario = new Usuario();
                        Usuario.id_usuario = Convert.ToInt32(reader["id"]);
                        Usuario.nombre_De_Usuario = reader["nombre_de_usuario"].ToString();
                        Usuarios.Add(Usuario);
                    }
                }
                connection.Close();
            }
            return Usuarios;
        }
        }
        public void Crear(Usuario usuarioCreado){
         var query = $"INSERT INTO usuario (id, nombre_de_usuario) VALUES (@id,@nombre_de_usuario)";
         using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
            connection.Open();

            var command = new SQLiteCommand(query, connection);

            command.Parameters.Add(new SQLiteParameter("@id", usuarioCreado.id_usuario));
            command.Parameters.Add(new SQLiteParameter("@nombre_de_usuario", usuarioCreado.nombre_De_Usuario));

            command.ExecuteNonQuery();
            connection.Close();
         }
    }
    }
}
