using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SapperTest.Data;
using SapperTest.Mdels;
using System.Linq.Expressions;

namespace SapperTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewController : Controller
    {
        [HttpPost]
        public ActionResult<GameResponseModel> CreatGame(GameRequestModel newGame)
        {
            var response = new GameResponseModel
            {
                GameId = Guid.NewGuid().ToString(),
                Width = newGame.Width,
                Heigth = newGame.Height,
                MinesCount = newGame.MinesCount,
            };

            var field = new List<string[]>();

            for (int i = 0; i < response.Heigth; i++)
            {
                var row = new string[response.Width];

                for (int j = 0; j < row.Length; j++)
                {
                    row[j] = " ";
                }
                field.Add(row);
            }

            response.Field = field;

            return Ok(response);
        }
    }
}
