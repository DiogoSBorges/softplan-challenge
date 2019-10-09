using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diogo.Softplan.Challenge.Api2.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Diogo.Softplan.Challenge.Api2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IApi1Service _api1Service;

        public ValuesController(IApi1Service api1Service)
        {
            _api1Service = api1Service;
        }

        /// <summary>
        /// GET api/values
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            _api1Service.ObterTaxaDeJurosAsync();
            return new string[] { "value1", "value2" };
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
