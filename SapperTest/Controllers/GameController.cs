using Microsoft.AspNetCore.Mvc;
using SapperTest.Data;
using SapperTest.Models;
using SapperTest.Services;

namespace SapperTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {
        private static Game _game;

        [HttpPost("new")]
        public ActionResult<GameResponseModel> New(GameRequestModel newGame)
        {
            var message = GameChecker.CheckUserSettings(newGame.Width, newGame.Height, newGame.MinesCount);

            if (message != string.Empty)
            {
                return BadRequest(new { Error = message});
            }

            _game = new Game(newGame.Height, newGame.Width, newGame.MinesCount);
            _game.Init();

            var responseModel = new GameResponseModel
            {
                GameId = _game.GameId,
                Width = _game.Col,
                Heigth = _game.Row,
                MinesCount = _game.MinesCount,
                Field = GameServices.CreateResponseField(_game.Field)
            };

            return Ok(responseModel);
        }

        [HttpPost("turn")]
        public ActionResult<TurnResponseModel> Index(TurnRequestModel userChoice)
        {
            _game.OpenCells(userChoice.Row, userChoice.Col);

            var win = _game.ClearedMines();
            var lost = _game.CatchMine(userChoice.Row, userChoice.Col);

            if (win || lost)
            {
                _game.End();
            }

            var responseModel = new TurnResponseModel
            {
                GameId = userChoice.GameId,
                Row = _game.Row,
                Col = _game.Col,
                MinesCount = _game.MinesCount,
                Completed = _game.Completed,
                Field = GameServices.CreateResponseField(_game.Field)
            };

            return Ok(responseModel);
        }
    }
}
