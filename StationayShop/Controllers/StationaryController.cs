using Microsoft.AspNetCore.Mvc;
using StationayShop.Model;
using StationayShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StationayShop.Controllers
{
    
    [Produces("application/json")]
    [Route("api/Stationary")]
    public class StationaryController : ControllerBase
    {
        private readonly IStationaryRepo _stationaryRepo;

        public StationaryController(IStationaryRepo stationaryRepo)
        {
            _stationaryRepo = stationaryRepo;
        }
        // GET: api/<Stationary>
        [HttpGet]
        public IActionResult Get()
        {
            var products = _stationaryRepo.GetStationaries();
            return new OkObjectResult(products);
            //return new string[] { "value1", "value2" };
        }

        // GET api/<Stationary>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _stationaryRepo.GetStationaryById(id);
            return new OkObjectResult(product);
            //return "value";
        }

        // POST api/<Stationary>
        [HttpPost]
        public IActionResult Post([FromBody] Stationary stationary)
        {
            using (var scope = new TransactionScope())
            {
                _stationaryRepo.InsertStationary(stationary);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = stationary.Id }, stationary);
            }
        }

        // PUT api/<Stationary>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Stationary stationary)
        {
            if (stationary != null)
            {
                using (var scope = new TransactionScope())
                {
                    _stationaryRepo.UpdateStationary(stationary);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/<Stationary>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _stationaryRepo.DeleteStationary(id);
            return new OkResult();
        }
    }
}
