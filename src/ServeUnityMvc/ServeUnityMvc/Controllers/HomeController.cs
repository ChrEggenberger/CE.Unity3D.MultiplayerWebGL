using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServeUnityMvc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ContentResult Index()
        {
            string indexContent = System.IO.File.ReadAllText(Server.MapPath("/Index.html"));
            // string indexContent = System.IO.File.ReadAllText(System.IO.Path.Combine(Request.PhysicalApplicationPath	,"Index.html"));//"C:\\Users\\Public\\Documents\\ServeUnityMvc\\ServeUnityMvc\\"	string

            return Content(indexContent);
        }

    }
}
