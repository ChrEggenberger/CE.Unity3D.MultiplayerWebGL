using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ServeUnityMvc.Controllers
{
    public class UnityStaticFileController : Controller
    {

        [OutputCache(Duration = 1200, VaryByHeader = "Accept-Encoding")]


        public ActionResult Index(string file, string path)
        {
            bool fileCompressed = false;
            bool fileExists = false;
            string filePath = file;// Path.Combine(path, file);
            #region verfy existing file
            if (System.IO.File.Exists(Server.MapPath(filePath)))
            {
                fileCompressed = file.EndsWith("gz");
                fileExists = true;
            }
            else
            {
                if (file.EndsWith("gz"))
                {
                    filePath = filePath.Substring(0, filePath.Length - 2);
                    fileCompressed = false;
                }
                else
                {
                    filePath += "gz";
                    fileCompressed = true;
                }
                fileExists = System.IO.File.Exists(Server.MapPath(filePath));
            }
            #endregion

            if (fileExists)
            {
                var acceptEncoding = Request.Headers.AllKeys.FirstOrDefault(key => key.ToLower() == "accept-encoding");

                // if no accept encoding header, return raw file (eww)
                if (acceptEncoding == null || !fileCompressed)
                    return new FilePathResult(filePath, getContentType(file));
                // if accept encoding gzip, return compressed files
                if (Request.Headers[acceptEncoding].Contains("gzip"))
                {
                    Response.Headers.Add("Content-Encoding", "gzip");
                    return new FilePathResult(filePath, getContentType(file));
                }
            }
            // bad request
            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
        }
        private string getContentType(string file)
        {
            var ext = Path.GetExtension(file);
            if (ext.Contains("js"))
                return "text/javascript; charset=UTF-8";
            // else
            return "application/x-octet-stream";
        }

    }
}
