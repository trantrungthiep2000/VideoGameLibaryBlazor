namespace VideoGameLibary.Shared.Models
{
    /// <summary>
    /// Information of video game
    /// CreatedBy: ThiepTT(18/09/2023)
    /// </summary>
    public class VideoGame
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Publisher
        /// </summary>
        public string Publisher { get; set; } = string.Empty;

        /// <summary>
        /// Release year
        /// </summary>
        public int ReleaseYear { get; set; }
    }
}