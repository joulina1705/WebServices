using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsomationWebService.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConverteurDevice()
        {
            Session["somme"] =  0;
            Session["resultat"] = 0;
            Session["op1"] = ConsomationWebService.ServiceReference1.Currency.EUR;
            Session["op2"] = ConsomationWebService.ServiceReference1.Currency.MAD;
            List <ConsomationWebService.ServiceReference1.Currency> l = new List<ConsomationWebService.ServiceReference1.Currency>();
            l = Enum.GetValues(typeof(ConsomationWebService.ServiceReference1.Currency)).Cast<ServiceReference1.Currency>().ToList();
            return View(l);
            
        }
        [HttpPost]
        public ActionResult ConverteurDevice(ConsomationWebService.ServiceReference1.Currency listbox1, ConsomationWebService.ServiceReference1.Currency listbox2,string argent)
        {
            ServiceReference1.CurrencyConvertorSoapClient client = new ServiceReference1.CurrencyConvertorSoapClient();

            Session["somme"] = client.ConversionRate(listbox1, listbox2);
            Session["resultat"] = Double.Parse(argent);
            Session["op1"] = listbox1;
            Session["op2"] = listbox2;

            List<ConsomationWebService.ServiceReference1.Currency> l = new List<ConsomationWebService.ServiceReference1.Currency>();
            l = Enum.GetValues(typeof(ConsomationWebService.ServiceReference1.Currency)).Cast<ServiceReference1.Currency>().ToList();
            return View(l);
        }
        public ActionResult ConvertisseurTemperature()
        {
            Session["temp"] = 0;
            Session["temperature"] = 0;
            Session["temp1"] = ConsomationWebService.ServiceReference2.TemperatureUnit.degreeCelsius;
            Session["temp2"] = ConsomationWebService.ServiceReference2.TemperatureUnit.kelvin;
            List<ConsomationWebService.ServiceReference2.TemperatureUnit> l = new List<ConsomationWebService.ServiceReference2.TemperatureUnit>();
            l = Enum.GetValues(typeof(ConsomationWebService.ServiceReference2.TemperatureUnit)).Cast<ConsomationWebService.ServiceReference2.TemperatureUnit>().ToList();
            return View(l);

        }
        [HttpPost]
        public ActionResult ConvertisseurTemperature(ConsomationWebService.ServiceReference2.TemperatureUnit listbox1, ConsomationWebService.ServiceReference2.TemperatureUnit listbox2, string temperature)
        {
            ServiceReference2.ConvertTemperatureSoapClient client = new ServiceReference2.ConvertTemperatureSoapClient();
            Session["temp"] = temperature;
            Session["temperature"] = client.ConvertTemp(Double.Parse(temperature), listbox1,listbox2).ToString();
            Session["temp1"] = listbox1;
            Session["temp2"] = listbox2;

            List<ConsomationWebService.ServiceReference2.TemperatureUnit> l = new List<ConsomationWebService.ServiceReference2.TemperatureUnit>();
            l = Enum.GetValues(typeof(ConsomationWebService.ServiceReference2.TemperatureUnit)).Cast<ConsomationWebService.ServiceReference2.TemperatureUnit>().ToList();
            return View(l);
        }

        public ActionResult Calculator()
        {
            Session["a"] = 0;
            Session["b"] =0;
            Session["a+b"] = 0;
            Session["a-b"] = 0;
            Session["a*b"] = 0;
            return View();

        }
        [HttpPost]
        public ActionResult Calculator(double a, double b)
        {
            ServiceReference3.WebServiceCaculatorSoapClient client = new ServiceReference3.WebServiceCaculatorSoapClient();
            Session["a"] = a;
            Session["b"] = b;
            Session["a+b"] = client.Addition(a,b);
            Session["a-b"] = client.Soustraction(a,b);
            Session["a*b"] = client.Multiplication(a,b);

            List<ConsomationWebService.ServiceReference2.TemperatureUnit> l = new List<ConsomationWebService.ServiceReference2.TemperatureUnit>();
            l = Enum.GetValues(typeof(ConsomationWebService.ServiceReference2.TemperatureUnit)).Cast<ConsomationWebService.ServiceReference2.TemperatureUnit>().ToList();
            return View(l);
        }

    }
}