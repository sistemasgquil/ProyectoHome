using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Listas0.Models
{
    public class LogOnModel
    {
        public int idusuario_ { get; set; }
        public string nombre { get; set; }
        public Boolean estado { get; set; }

        string conex = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        DataSet ds;
        public DataTable GetgridData()
        {
            try
            {
                ds = new DataSet();
                SqlConnection con = new SqlConnection(conex);
                SqlDataAdapter ada = new SqlDataAdapter("select top(1) codigo,nombre from usuario(nolock) where empresa=1 and sucursal=1", conex);
                ada.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                throw err;
            }
        }


    }




}