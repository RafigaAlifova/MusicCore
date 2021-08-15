using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")] // www.k201.com/api/movies/getall
    [ApiController]
    public class MusicsController : ControllerBase
    {
        IMusicService _musicService;

        public MusicsController(IMusicService musicService)
        {
            _musicService = musicService;
        }

        [HttpPost("add")]  // www.k201.com/api/movies/add
        public IActionResult Add(Music music)
        {
            var result = this._musicService.Add(music);
            if (result.Success)
            {
                return Ok(result.Message); //200
            }

            return BadRequest(result.Message); //400
        }

        [HttpPost("update")]
        public IActionResult Update(Music music)
        {
            var result = this._musicService.Update(music);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message); 
        }
        
        [HttpPost("delete")]
        public IActionResult Delete(Music music)
        {
            var result = this._musicService.Delete(music);
            if (result.Success)
            {
                return Ok(result.Message); 
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getall")]  // www.k201.com/api/musics/getall
        public IActionResult GetAll()
        {
            var result = this._musicService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data); 
            }

            return BadRequest(result.Message); 
        }

        [HttpGet("getgenres")]   // www.k201.com/api/Musics/getgenres?genreid=9
        public IActionResult GetByGenreId(int genreId)
        {
            var result = this._musicService.GetByGenreId(genreId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }


    }
}
