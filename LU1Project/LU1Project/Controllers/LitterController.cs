using LU1Project.Models;
using LU1Project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LU1Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LitterController : ControllerBase
    {
        private readonly LitterDbContext _context;
        public LitterController(LitterDbContext context)
        {
            _context = context;
        }

        private static readonly string[] SoortenAfval = new[]
        {
            "Cola", "Water", "Fles", "Blik", "Sigaret"
        };

        private static readonly string[] Locations = new[]
        {
            "Breda", "Roosendaal", "Etten-Leur", "Tilburg", "Eindhoven"
        };

        private static readonly string[] Colors = new[]
        {
            "Red", "Blue", "Yellow", "White", "Black"
        };

        private readonly ILogger<LitterController> _logger;

        public LitterController(ILogger<LitterController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "PostLitter")]
        public Litter Post([FromBody] Litter litter)
        {
            litter.Id = Random.Shared.Next(0, 15);
            litter.ReportDate = DateTime.UtcNow;

            Console.WriteLine($"Received Litter:\n" +
                $"Id: {litter.Id}\n" +
                $"Location: {litter.Location}\n" +
                $"Description: {litter.Description}\n" +
                $"DateTime: {litter.ReportDate}\n" +
                $"Color: {litter.Color}");

            return litter;
        }

        [HttpGet(Name = "GetLitter")]
        public Litter Get()
        {
            return new Litter
            {
                Id = Random.Shared.Next(0, 15),
                Location = Locations[Random.Shared.Next(Locations.Length)],
                Description = SoortenAfval[Random.Shared.Next(SoortenAfval.Length)],
                ReportDate = DateTime.Now.AddDays(1),
                Color = Colors[Random.Shared.Next(Colors.Length)]
            };
        }
    }
}