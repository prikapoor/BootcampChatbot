using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService1
{
    /// <summary>
    /// Summary description for WebServiceExample1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceExample1 : System.Web.Services.WebService
    {
        [WebMethod]
        public string Message()
        {
            return "Hello Guys";
        }

        [WebMethod]
        public List<string> GetAllEmployees()
        {
            return new List<string>
            {
                "Deepika",
                "Pooja",
                "Sharanya",
                "Navneet",
                "Jyoti",
                "Varun",
            };

        }
        [WebMethod]
        public DataSet GetAllModels()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS01;Initial Catalog=PhilipsDB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM PATIENTMONITORS", con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                DataSet ds = new DataSet();
                DataTable table = new DataTable("Model");
                table.Load(reader);
                ds.Tables.Add(table);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
