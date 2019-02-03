using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChoresApi.Models.Other;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace chores_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private AppConfiguration _appConfig;

        public HealthCheckController(IOptions<AppConfiguration> appConfig)
        {
            _appConfig = appConfig.Value;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<AppConfiguration> Get()
        {
            return _appConfig;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
