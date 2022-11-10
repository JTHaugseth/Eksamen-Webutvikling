using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using electricgamesApi.Service;
using electricgamesApi.Collection;

namespace electricgamesApi.Controllers;

[ApiController]
[Route("Game/[controller]")]

public class GamesController : ControllerBase {

    private readonly ILogger<GamesController> _logger;

    private readonly GamesService _gamesService;

    private readonly IWebHostEnvironment _hosting;

    public GamesController(ILogger<GamesController> logger, GamesService gamesService, IWebHostEnvironment hosting) {
        _logger = logger;
        _gamesService = gamesService;
        _hosting = hosting;
    }

    [HttpGet]

    public ActionResult<List<Games>> Get() {
        return _gamesService.Get();
    }

    [HttpGet("{id}")]

    public ActionResult<Games> GetGamesById(string Id) {
        var games = _gamesService.Get(Id);
        if(games == null) {
            return NotFound();
        }
        return games;
    }

    [HttpPost] 

    public IActionResult Post([FromBody] Games newGame) {
        
        _gamesService.Create(newGame);
        return CreatedAtAction(nameof(Post), new {id = newGame.Id}, newGame);
    } 

    [HttpPut("{Id}")]

    public IActionResult Update([FromRoute] string Id, [FromBody] Games updateGame) {
        var game = _gamesService.Get(Id);
        if(game == null) {
            return NotFound();
        } 
        _gamesService.Update(Id, updateGame);
        return CreatedAtAction(nameof(Update), new {id = updateGame.Id}, updateGame);
    }

    [HttpPut("{Id}")]

    public IActionResult DeleteById(string Id) {
        var game = _gamesService.Get(Id);
        if(game == null) {
            return NotFound();
        }
        _gamesService.Remove(Id);
        return Ok();
    }
}