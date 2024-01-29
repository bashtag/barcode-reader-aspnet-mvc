using System;
using System.Drawing;
using System.IO;
using System.Web.Mvc;
using ZXing;
using BarcodeReaderMVC.Models;

namespace BarcodeReaderMVC.Controllers
{
    public class ScannerController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Scan(RawImageData imageData)
        {
            try
            {
                if (imageData == null || string.IsNullOrEmpty(imageData.Value))
                {
                    return Json(new { success = false, message = "No image data sent." });
                }

                // imageData.Value is now a Base64 string representing the image
                // Convert Base64 string to a byte array
                var base64Data = imageData.Value.Split(',')[1];
                var bytes = Convert.FromBase64String(base64Data);

                using (var ms = new MemoryStream(bytes))
                {
                    using (var bitmap = new Bitmap(ms))
                    {
                        var reader = new BarcodeReader();
                        var result = reader.Decode(bitmap);
                        if (result != null)
                        {
                            return Json(new { success = true, text = result.Text });
                        }
                        else
                        {
                            return Json(new { success = false, message = "No barcode detected." });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception here
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}