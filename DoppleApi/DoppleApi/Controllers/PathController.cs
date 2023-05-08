using Microsoft.AspNetCore.Mvc;

namespace DoppleApi.Controllers
{
    //this clas is used for validation purposes
    // it gets the path from the other controllers and sends it to jsonDraft007, and will accordingly send it to the XSDValidator 
    //this class is working , but not used
    public class PathController : Controller
    {
        [NonAction]
        public String GetUri()
        {
            //var message = HttpContext.Request.Path.Value;
           // var message1 = HttpContext.Session.GetString;
            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
            var ok = httpContextAccessor.HttpContext.Request.Path.Value;
            //Console.WriteLine(ok);
            return ok;

        }
    }
}
