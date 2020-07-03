using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Epra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace PostgresTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly EpraContext _ctx;

        public WeatherForecastController(EpraContext ctx)
        {
            _ctx = ctx;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var watch = new Stopwatch();
            watch.Start();
            var companies = await _ctx.companies
                .Include(c => c.CompanyType)
                .Include(c => c.Membership)
                .ToArrayAsync();
            watch.Stop();
            var a = watch.ElapsedMilliseconds;
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
