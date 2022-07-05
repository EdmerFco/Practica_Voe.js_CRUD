using CRUD_Vue.js.Entidades;
using System.Data.SqlClient;

namespace CRUD_Vue.js.Datos
{
    public class DAtosUsuario : DatosConexion
    {

        public IEnumerable<Usuario> Conultar()
        {
            List<Usuario> lista = new List<Usuario>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("Consultar", _Cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Usuario model = new Usuario()
                    {
                        Id = int.Parse(lector[0].ToString()),
                        Nombre = lector[1].ToString(),
                        ApellidoP = lector[2].ToString(),
                        ApellidoM = lector[3].ToString(),
                        FNacimiento = Convert.ToDateTime(lector[4].ToString()),
                        Curp = lector[5].ToString(),
                        Correo = lector[6].ToString(),
                        Telefono = lector[7].ToString()

                    };
                    lista.Add(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Desconexion();
            }
            return lista;
        }

        public Usuario ConsultarUNO(int id)
        {
            Usuario usuario = new Usuario();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("ConsultarUno", _Cnn);
                comando.Parameters.Add(new SqlParameter("@id", id));
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    usuario = new Usuario()
                    {
                        Id = int.Parse(lector[0].ToString()),
                        Nombre = lector[1].ToString(),
                        ApellidoP = lector[2].ToString(),
                        ApellidoM = lector[3].ToString(),
                        FNacimiento = Convert.ToDateTime(lector[4].ToString()),
                        Curp = lector[5].ToString(),
                        Correo = lector[6].ToString(),
                        Telefono = lector[7].ToString()
                    };

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);

            }
            finally
            {
                Desconexion();
            }
            return usuario;
        }

        public void Agregar(Usuario usuario)
        {
            Conectar();
            try
            {
                SqlCommand con = new SqlCommand("Agregar", _Cnn);
                
                    con.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    con.Parameters.AddWithValue("@ApellidoP", usuario.ApellidoP);
                    con.Parameters.AddWithValue("@ApellidoM", usuario.ApellidoM);
                    con.Parameters.AddWithValue("@FNacimiento", usuario.FNacimiento);
                    con.Parameters.AddWithValue("@Curp", usuario.Curp);
                    con.Parameters.AddWithValue("@Correo", usuario.Correo);
                    con.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                    con.ExecuteScalar();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Desconexion();
            }
        }
        public void Actualizar(Usuario usuario)
        {
            Conectar();
            try
            {

                SqlCommand con = new SqlCommand("Actualizar", _Cnn);
                    con.CommandType = System.Data.CommandType.StoredProcedure;
                con.Parameters.AddWithValue("@idUsuario", usuario.Id);
                con.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    con.Parameters.AddWithValue("@ApellidoP", usuario.ApellidoP);
                    con.Parameters.AddWithValue("@ApellidoM", usuario.ApellidoM);
                    con.Parameters.AddWithValue("@FNacimiento", usuario.FNacimiento);
                    con.Parameters.AddWithValue("@Curp", usuario.Curp);
                    con.Parameters.AddWithValue("@Correo", usuario.Correo);
                    con.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                    con.ExecuteScalar();
                

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Desconexion();
            }
        }

        public void Eliminar(int id)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("Eliminar", _Cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", id);

                comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Desconexion();
            }
        }
    }
}
