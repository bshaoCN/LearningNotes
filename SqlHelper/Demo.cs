using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SqlHelper
{
    public class Demo
    {
        public static void Test()
        {
            SqlConnectionStringBuilder builder =new SqlConnectionStringBuilder();
            builder["Server"] = @".\SQLExpress";
            builder["Database"] = "test";
            builder["Trusted_Connection"] = "True";
            using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {
                string qry=@"SELECT * FROM value";
                DataTable dt = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(qry, conn))
                {
                    adapter.Fill(dt);
                    Console.WriteLine(dt.Rows.Count +" rows.");

                    var dr = dt.NewRow();
                    dr["id"] = 5;
                    dr["value"] = 'e';
                    dt.Rows.Add(dr);

                    SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                    cmdBuilder.GetInsertCommand();
                    adapter.Update(dt);
                }
                

                Console.WriteLine(dt.Rows.Count + " rows.");
            }

        }
    }
}
