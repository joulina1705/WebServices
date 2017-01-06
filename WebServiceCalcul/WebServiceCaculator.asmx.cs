using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServiceCalcul
{
    /// <summary>
    /// Summary description for WebServiceCaculator
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceCaculator : System.Web.Services.WebService
    {

        [WebMethod]
        public double Addition(double a, double b)
        {
            return a+b;
        }
        [WebMethod]
        public double Soustraction(double a, double b)
        {
            return a-b;
        }
        [WebMethod]
        public double Multiplication(double a, double b)
        {
            return a * b;
        }
    }
}
