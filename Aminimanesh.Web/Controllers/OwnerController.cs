using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Aminimanesh.Web.Controllers
{
    public class OwnerController : Controller
    {
        [Route("download-cv")]
        public async Task<IActionResult> DownloadCV()
        {
            try
            {
                var cvFileName = "Amini Manesh - CV.pdf";
                var cvPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/owner/doc/");

                var cvFullPath = Path.Combine(cvPath, cvFileName);

                // Check if the file exists
                if (!System.IO.File.Exists(cvFullPath))
                {
                    return NotFound(); // Return 404 Not Found if the file does not exist
                }

                // Read the file content asynchronously
                var stream = new FileStream(cvFullPath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true);
                return File(stream, "application/force-download", cvFileName);
            }
            catch (Exception ex)
            {
                // Log any exceptions
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
