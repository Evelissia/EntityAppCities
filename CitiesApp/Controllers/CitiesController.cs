using CitiesApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CitiesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : Controller
    {
        ApplicationContext _context;

        public CitiesController(ApplicationContext context)
        {
            this._context = context;
        }

        /*[HttpGet("parse")]
        public ActionResult<City> Post()
        {
            string URL = "https://raw.githubusercontent.com/pensnarik/russian-cities/master/russian-cities.json";
            WebRequest request = WebRequest.Create(URL);
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = @reader.ReadToEnd();

                List<City> city = Newtonsoft.Json.JsonConvert.DeserializeObject<List<City>>(responseFromServer);
                _context.AddRange(city);
                _context.SaveChanges();
            }

            // Close the response.
            response.Close();
            return Ok();
        }*/

        [HttpGet()]
        public List<City> GetCities()
        {
            return _context.Cities.Include(x=>x.coords).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> Get(int id)
        {
            City city = await _context.Cities.Include(x => x.coords).FirstOrDefaultAsync(x => x.Id == id);
            if(city == null)
            {
                return NotFound();
            }
            return new ObjectResult(city);
        }


    }
}
