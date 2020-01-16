using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWPFReport
{
    public static class Connection
    {
        private static SqlConnection getConnection()
        {
            return new SqlConnection("Data Source=.;Initial Catalog=reportdb;Integrated Security=True");
        }

        public static DataSet getDataSet(int id_factura)
        {
            using(SqlConnection conn = getConnection())
            {
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "exec calcular_factura " + id_factura;
                da.SelectCommand = cmd;
                da.Fill(ds, "hola");
                cmd.CommandText = "exec lineas_factura " + id_factura;
                da.SelectCommand = cmd;
                da.Fill(ds, "hola2");
                conn.Close();
                return ds;
            }
        } 
    }
}
