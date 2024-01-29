using System.Web.Mvc;

namespace BarcodeReaderMVC.Controllers
{
    public class SampleController : Controller
    {
        // GET: Sample
        public ActionResult Index()
        {
            return View();
        }

        // GET: Sample/GetData
        public JsonResult GetData()
        {
            // Simulate data - this could come from a database or other source
            var data = new { Name = "John Doe", Age = 30 };

            // Return the data as JSON
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}