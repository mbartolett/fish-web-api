using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WiscFish.Repo;
using WiscFish.Models;
using Newtonsoft.Json;

namespace WiscFish.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PinsController : ControllerBase
    {
        private readonly IPinsRepo _pinsRepo;

        public PinsController(IPinsRepo pinsRepo)
        {
            _pinsRepo = pinsRepo;
        }

        // GET: api/Pins
        [HttpGet]
        public async Task<List<Pins>> Get()
        {
            return await _pinsRepo.GetPins();
        }

        // GET: api/Pins/5
        [HttpGet("{year}", Name = "Get")]
        public async Task<List<Pins>> Get(string year)
        {
            return await _pinsRepo.GetPins(year);
        }

        // POST: api/Pins
        [HttpPost]
        public void Post([FromBody] Pins Pin)
        {
            if (Pin != null)
            {  
                _pinsRepo.PostPins(Pin);
            }           
        }

        // PUT: api/Pins/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
