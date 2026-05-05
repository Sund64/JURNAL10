using Microsoft.AspNetCore.Mvc;

namespace MODUL10_103022400075.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private static List<Game>_games = new List<Game>
        {
            new Game { nama = "Valorant", developer = "Riot Games", tahunRilis = 2020, genre = "FPS", rating = 8.5, platform = ["PC"], mode = ["Multiplayer"], isOnline = true, harga = 0},
            new Game { nama = "GTA V", developer = "Rockstar Games", tahunRilis = 2013, genre = "Open World", rating = 9.5, platform = ["PC","PS4","PS5","Xbox"], mode = ["Singleplayer","Multiplayer"], isOnline = true, harga = 300000},
            new Game { nama = "The Witcher 3", developer = "CD Project Red", tahunRilis = 2015, genre = "RPG", rating = 9.7, platform = ["PC","PS4","PS5","Xbox","Switch"], mode = ["Singleplayer"], isOnline = false, harga = 250000}
        };
        [HttpGet]
        public ActionResult<IEnumerable<Game>> Get()
        {
            return Ok(_games);
        }

        [HttpGet("{nama}")]
        public ActionResult<Game> Get(string nama)
        {
            var game = _games.FirstOrDefault(f => f.nama == nama);
            if (game == null) return NotFound();
            return Ok(game);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Game newGame)
        {
            _games.Add(newGame);
            return Ok(newGame);
        }
        [HttpPut("{nama}")]
        public ActionResult<Game> Put([FromBody] Game newGame, string nama)
        {
            var game = _games.FindIndex(f => f.nama == nama);
            if (game == -1) return NotFound();
            _games[game] = newGame;
            return Ok(newGame);
        }
            



        [HttpDelete("{nama}")]
        public ActionResult Delete(string nama)
        {
            var game = _games.FirstOrDefault(f => f.nama == nama);
            if (game == null) return NotFound();

            _games.Remove(game);
            return Ok();
        }
    }
}