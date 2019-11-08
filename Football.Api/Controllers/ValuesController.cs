using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Football.core;
using Football.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace Football.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IFootballService _service;

        public ValuesController(IFootballService service)
        {
            _service = service;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GelAllTeams());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == default)
                return BadRequest();

            var matches= _service.GetMatchesByTeamId(id);
            List<string> form=new List<string>();
            foreach (var match in matches)
            {
                if (match.Home == id)
                {
                    if(match.HomeScore > match.GuestScore) 
                        form.Add("W");
                    else if(match.HomeScore<match.GuestScore)
                        form.Add("L");
                    else
                    {
                        form.Add("D");
                    }
                }
                else if(match.Guest == id)
                {
                    if (match.GuestScore > match.HomeScore)
                        form.Add("W");
                    else if (match.GuestScore < match.HomeScore)
                        form.Add("L");
                    else
                    {
                        form.Add("D");
                    }
                }
            }

            return Ok(form);
        }

        // POST api/values
        [HttpPost("AddTeam")]
        public IActionResult AddTeam([FromBody] Teams model)
        {
            if (ModelState.IsValid)
            {
                _service.AddTeam(model);
            }
            return Ok("team added");

        }
        [HttpPost("AddMatch")]
        public IActionResult AddMatch([FromBody] Matches model)
        {
            if (ModelState.IsValid)
            {
                _service.AddMatch(model);
            }
            return Ok("match added");

        }
        // PUT api/values/5
        [HttpPut("UpdateTeam")]
        public void UpdateTeam([FromBody] Teams model)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateTeam(model);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
