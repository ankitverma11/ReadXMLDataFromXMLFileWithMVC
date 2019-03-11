using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReadXMLDataFromXML.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var Data = new List<Models.CustomerModel>();
            Data = ReturnData();
            return View(Data);
        }

        public List<Models.CustomerModel> ReturnData()
        {
            var CuustomerList = new List<Models.CustomerModel>();
            string XMLData = Server.MapPath("~/XML/CustomerData.XML");
            DataSet ds = new DataSet();
            ds.ReadXml(XMLData);

            CuustomerList = (from rows in ds.Tables[0].AsEnumerable()
                             select new Models.CustomerModel
                             {
                                 CustomerID = rows[0].ToString(),
                                 CustomrName = rows[1].ToString(),
                                 Contact = rows[2].ToString()
                             }).ToList();

            return CuustomerList;
        }
    }
}