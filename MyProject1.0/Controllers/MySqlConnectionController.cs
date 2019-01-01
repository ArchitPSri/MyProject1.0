using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DBConnection;
using DAO;
using System.Data;
using System.Data.SqlClient;


namespace MyProject1._0.Controllers
{
    [Route("api/[controller]")]
    public class MySqlConnectionController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    CallDB();
                    return 32 + (int)(TemperatureC / 0.5556);
                    
                }
                
            }

            private string databaseName = string.Empty;
            
            public void CallDB()
            {
                try
                {
                    GetData getData = new GetData();
                    getData.CallDB();
                }
                catch(Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("    CONN FAILED     ");
                    Console.WriteLine(e);
                }
            }
        }
    }
}
