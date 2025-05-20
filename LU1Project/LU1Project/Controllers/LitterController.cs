using LU1Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace LU1Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LitterController : ControllerBase
    {
        private static readonly string[] SoortenAfval = new[]
        {
            "Cola", "Water", "Fles", "Blik", "Sigaret"
        };

        private static readonly string[] Locations = new[]
        {
            "Breda", "Roosendaal", "Etten-Leur", "Tilburg", "Eindhoven"
        };

        private readonly ILogger<LitterController> _logger;

        public LitterController(ILogger<LitterController> logger)
        {
            _logger = logger;
        }

        // POST here.

        [HttpGet(Name = "GetLitter")]
        public Litter Get()
        {
            return new Litter
            {
                Id = Random.Shared.Next(0, 15),
                Location = Locations[Random.Shared.Next(Locations.Length)],
                Description = SoortenAfval[Random.Shared.Next(SoortenAfval.Length)],
                DateTime = DateTime.Now.AddDays(1)
            };
        }
    }
}
