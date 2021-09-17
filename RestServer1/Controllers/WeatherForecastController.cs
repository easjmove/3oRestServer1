using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using RestServer1.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestServer1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private WeatherForecastManager _manager;
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMemoryCache _memoryCache;
        private readonly string WeatherForecastGetKey = "WeatherForecastGetKey";

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
            _manager = new WeatherForecastManager();
        }

        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false)]
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            IEnumerable<WeatherForecast> weatherForecastCollection = null;
            if (_memoryCache.TryGetValue(WeatherForecastGetKey, out weatherForecastCollection))
            {
                return weatherForecastCollection;
            }

            weatherForecastCollection = _manager.CreateWeatherForecasts();

            var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(30));
            _memoryCache.Set(WeatherForecastGetKey, weatherForecastCollection, cacheOptions);

            return weatherForecastCollection;
        }

        
    }
}
