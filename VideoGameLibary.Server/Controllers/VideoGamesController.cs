using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameLibary.Server.Data;

namespace VideoGameLibary.Server.Controllers
{
    /// <summary>
    /// Information of video games
    /// CreatedBy: ThiepTT(17/09/2023)
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
        /// CreatedBy: ThiepTT(17/09/2023)
        public async Task<IActionResult> GetAllVideoGames()
        {
            var videoGames = await _dataContext.VideoGames.ToListAsync();

            return Ok(videoGames);
        }
    }
}