using LU1Project.Models;
using LU1Project.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LU1Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LitterController : ControllerBase
    {
        private readonly LitterDbContext _context;
        private readonly ILogger<LitterController> _logger;
        public LitterController(LitterDbContext context, ILogger<LitterController> logger)
        {
            _context = context;
            _logger = logger;
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

        //[HttpPost(Name = "PostLitter")]
        //public Litter Post([FromBody] Litter litter)
        //{
        //    litter.Id = Random.Shared.Next(0, 15);
        //    litter.ReportDate = DateTime.UtcNow;

        //    Console.WriteLine($"Received Litter:\n" +
        //        $"Id: {litter.Id}\n" +
        //        $"Location: {litter.Location}\n" +
        //        $"Description: {litter.Description}\n" +
        //        $"DateTime: {litter.ReportDate}\n" +
        //        $"Color: {litter.Color}");

        //    return litter;
        //}

        [HttpPost(Name = "PostLitter")]
        public async Task<IActionResult> Post([FromBody] Litter litter)
        {
            litter.ReportDate = DateTime.UtcNow;

            _context.Litter.Add(litter);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = litter.Id }, litter);
        }

        //[HttpGet(Name = "GetLitter")]
        //public Litter Get()
        //{
        //    return new Litter
        //    {
        //        Id = Random.Shared.Next(0, 15),
        //        Location = Locations[Random.Shared.Next(Locations.Length)],
        //        Description = SoortenAfval[Random.Shared.Next(SoortenAfval.Length)],
        //        ReportDate = DateTime.Now.AddDays(1),
        //        Color = Colors[Random.Shared.Next(Colors.Length)]
        //    };
        //}

        [HttpGet(Name = "GetAllLitter")]
        public async Task<ActionResult<IEnumerable<Litter>>> Get()
        {
            var litterReports = await _context.Litter.ToListAsync();
            return Ok(litterReports);
        }
    }
}