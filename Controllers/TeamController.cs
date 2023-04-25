using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using postgressdb.Models;

namespace postgressdb.Controllers;


[Route("api/[controller]")]
public class TeamController : Controller
{

    private List<Driver> drivers = new List<Driver> (){
        new Driver () {

        }
    };
    private List<Team> team = new List<Team>() {
        new Team(){
            Name = "Backend",
            year = 2022,
        },
        new Team(){
            Name = "Frontend",
            year = 2022,
        },
        new Team(){
            Name = "Mobile",
            year = 2022,
        },
    };
    [HttpGet]
    [Route("GetBestTeam")]
    public IActionResult Get() {
        return Ok(team);
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id) {
        var cur = team.FirstOrDefault(team => team.Id == id);
        if (cur == null) return BadRequest("invalid Id");
        return Ok(cur);
    }
    [HttpPost]
    public IActionResult Post(Team cur){
        team.Add(cur);
        return CreatedAtAction("Get", cur.Id, cur);
    }
    [HttpPatch]
    public IActionResult Patch(int id, string Name){
        var cur = team.FirstOrDefault(team=>team.Id == id);
        if (cur == null)return BadRequest("invalid data");
        cur.Name = Name;
        return NoContent();

    }
    [HttpDelete]
    public IActionResult Delete(int id){
        var cur = team.FirstOrDefault(team=>team.Id == id);
        if (cur == null)return BadRequest("Error");
        team.Remove(cur);
        return NoContent();
    }
}

