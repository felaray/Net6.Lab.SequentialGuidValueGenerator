#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Net6.Lab.GenId;
using Net6.Lab.GenId.Data;

namespace Net6.Lab.GenId.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastsController : ControllerBase
    {
        private readonly Net6LabGenIdContext _context;

        public WeatherForecastsController(Net6LabGenIdContext context)
        {
            _context = context;
        }

        // GET: api/WeatherForecasts
        //[HttpGet]
        //public async Task<ActionResult> GetWeatherForecast()
        //{
        //    return Ok(await _context.WeatherForecast.Select(c => c.Date).ToListAsync());
        //}

        /// <summary>
        /// 測試 SequentialGuidValueGenerator 產出的陣列
        /// </summary>
        /// <returns></returns>
        [HttpGet("genList")]
        public ActionResult Demo()
        {
            var gen = new SequentialGuidValueGenerator();
            var list = new List<Guid>();
            for (var i = 0; i < 10; i++)
            {
                list.Add(gen.Next(null));
            }
            return Ok(list);
        }

        [HttpPost]
        public async Task<ActionResult> AddData()
        {
            for (var i = 0; i < 10; i++)
            {
                _context.WeatherForecast.Add(new WeatherForecast
                {
                    Date = DateTime.Now,
                    Location = new List<Location>
                     {
                        new Location{ Name="aaa"},
                        new Location{ Name="bbb"},
                        new Location{ Name="ccc"}
                     }
                });
                await _context.SaveChangesAsync();
            }

            return Ok();
        }

        // DELETE: api/WeatherForecasts/5
        [HttpDelete]
        public async Task<IActionResult> DeleteWeatherForecast()
        {
            var weatherForecast = _context.WeatherForecast;
            _context.WeatherForecast.RemoveRange(weatherForecast);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> GetItem(Guid Id)
        {
            var res = await new Repository<WeatherForecast>(_context).SingleOrDefaultAsync(Id, "Location");
            return Ok(res);
        }
    }
}
