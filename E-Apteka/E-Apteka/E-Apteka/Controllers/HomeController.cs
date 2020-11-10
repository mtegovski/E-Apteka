using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Mvc;
namespace E_Apteka.Controllers
{
    public class HomeController : Controller
    {
        
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ExcelData()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ExcelData(HttpPostedFileBase file)
        {
            string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string filepath = "/ExcelData/" + filename;
            file.SaveAs(Path.Combine(Server.MapPath("/ExcelData"), filename));
            InsertExceldata(filepath, filename);
            return View();
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        OleDbConnection Econ;
        private void ExcelConn(string filepath)
        {
            string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\M1HA\source\repos\E-Apteka\E-Apteka\ExcelData\lekovi.xls;Extended Properties=Excel 12.0 Xml;", filepath);
            Econ = new OleDbConnection(constr);
        }
        private void InsertExceldata(string fileepath, string filename)
        {
            string fullpath = Server.MapPath("/ExcelData/") + filename;
            ExcelConn(fullpath);
            string query = string.Format("Select * from [{0}]", "Sheet1$");
            OleDbCommand Ecom = new OleDbCommand(query, Econ);
            Econ.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(query, Econ);
            Econ.Close();
            oda.Fill(ds);
            DataTable dt = ds.Tables[0];
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            objbulk.DestinationTableName = "Medicines";
           // objbulk.ColumnMappings.Add("LekID", "LekID");
            objbulk.ColumnMappings.Add("Name", "Name");
            objbulk.ColumnMappings.Add("Producer", "Producer");
            objbulk.ColumnMappings.Add("Price", "Price");
            con.Open();
            objbulk.WriteToServer(dt);
            con.Close();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}