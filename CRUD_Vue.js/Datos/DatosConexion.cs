using System.Data.SqlClient;

namespace CRUD_Vue.js.Datos
{
    public class DatosConexion
    {

        protected SqlConnection _Cnn; 
        protected void Conectar()
        {
            try
            {
                _Cnn = new SqlConnection("Data Source=PC-EDMER;Initial Catalog=CRUD_Vue;User ID=sa;Password=EDMERfco2022;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                _Cnn.Open();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);

            }
        }

        protected void Desconexion()
        {
            try
            {
                _Cnn.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine (ex.StackTrace);  
            }
        }
    }
}
