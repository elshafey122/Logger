using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
namespace LoggerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        private readonly string path = @"E:\courses\.net\Innoteck\Task 2\Logger.txt";
        [HttpPost("PostInFile")]
        public async Task<IActionResult> PostOnHard([FromBody] string Name)
        {
            try
            {
                if (!System.IO.File.Exists(path))
                {
                    return BadRequest("file is not exists");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.Values);
                }
                System.IO.File.AppendAllText(path, Name + Environment.NewLine);
                return Ok("text added to file successfully.");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetFromFile")]
        public IActionResult GetFileData()
        {
            List<string> DataList = new();
            string path = @"E:\courses\.net\Innoteck\Task 2\Logger.txt";
            if (!System.IO.File.Exists(path))
            {
                return BadRequest("file is not found");
            }
            foreach (string line in System.IO.File.ReadLines(path))
            {
                DataList.Add(line);
            }
            return Ok(DataList);
        }
    }
}
