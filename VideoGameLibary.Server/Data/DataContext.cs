using Microsoft.EntityFrameworkCore;
using VideoGameLibary.Server.Models;

namespace VideoGameLibary.Server.Data
{
    /// <summary>
    /// Information of data context
    /// CreatedBy:ThiepTT(17/09/2023)
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        /// <summary>
        /// Video games
        /// </summary>
        public DbSet<VideoGame> VideoGames { get; set; }
    }
}