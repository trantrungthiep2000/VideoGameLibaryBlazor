using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using VideoGameLibary.Server.Data;
using VideoGameLibary.Shared.Models;

namespace VideoGameLibary.Server.Controllers
{
    /// <summary>
    /// Information of video games
    /// CreatedBy: ThiepTT(18/09/2023)
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGamesController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public VideoGamesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Get all video games
        /// </summary>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(18/09/2023)
        [HttpGet]
        [Route("GetAllVideoGames")]
        public async Task<IActionResult> GetAllVideoGames()
        {
            var videoGames = await _dataContext.VideoGames.OrderBy(vg => vg.ReleaseYear).ToListAsync();

            return Ok(videoGames);
        }

        /// <summary>
        /// Get video game by id
        /// </summary>
        /// <param name="videoGameId">Id of video game</param>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(18/09/2023)
        [HttpGet]
        [Route("GetVideoGameById/{videoGameId}")]
        public async Task<IActionResult> GetVideoGameById([Required] int videoGameId)
        {
            var videoGame = await _dataContext.VideoGames.FirstOrDefaultAsync(videoGame => videoGame.Id == videoGameId);

            if (videoGame is null) 
            {
                return BadRequest($"No find video game with ID: {videoGameId}");
            }

            return Ok(videoGame);
        }

        /// <summary>
        /// Create a video game
        /// </summary>
        /// <param name="videoGame">VideoGame</param>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(18/09/2023)
        [HttpPost]
        [Route("CreateVideoGame")]
        public async Task<IActionResult> CreateVideoGame([FromBody] VideoGame videoGame)
        {
            _dataContext.VideoGames.Add(videoGame);
            var result = await _dataContext.SaveChangesAsync();

            return Ok(result);
        }

        /// <summary>
        /// Update a video game
        /// </summary>
        /// <param name="videoGame">VideoGame</param>
        /// <param name="videoGameId">Id of video game</param>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(18/09/2023)
        [HttpPut]
        [Route("UpdateVideoGame/{videoGameId}")]
        public async Task<IActionResult> UpdateVideoGame([FromBody] VideoGame videoGame, [Required] int videoGameId)
        {
            var videoGameById = await _dataContext.VideoGames.FirstOrDefaultAsync(videoGame => videoGame.Id == videoGameId);

            if (videoGameById is null)
            {
                return BadRequest($"No find video game with ID: {videoGameId}");
            }

            videoGameById.Title = videoGame.Title;
            videoGameById.Publisher = videoGame.Publisher;
            videoGameById.ReleaseYear = videoGame.ReleaseYear;

            _dataContext.VideoGames.Update(videoGameById);
            var result = await _dataContext.SaveChangesAsync();

            return Ok(result);
        }

        /// <summary>
        /// Delete a video game
        /// </summary>
        /// <param name="videoGameId">Id of video game</param>
        /// <returns>IActionResult</returns>
        /// CreatedBy: ThiepTT(18/09/2023)
        [HttpDelete]
        [Route("DeleteVideoGame/{videoGameId}")]
        public async Task<IActionResult> DeleteVideoGame([Required] int videoGameId)
        {
            var videoGame = await _dataContext.VideoGames.FirstOrDefaultAsync(videoGame => videoGame.Id == videoGameId);

            if (videoGame is null)
            {
                return BadRequest($"No find video game with ID: {videoGameId}");
            }

            _dataContext.VideoGames.Remove(videoGame);
            var result = await _dataContext.SaveChangesAsync();

            return Ok(result);
        }
    }
}