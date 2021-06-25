using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DeveloperTest.Controllers
{
    [ApiController, Route("[controller]")]
    public class CustomerTypeController : ControllerBase
    {
        private static readonly string[] Engineers = { "Large", "Small" };

        private readonly ILogger<EngineerController> _logger;

        public CustomerTypeController(ILogger<EngineerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Engineers;
        }
    }
}
