﻿using Microsoft.EntityFrameworkCore;
using VideoGameLibary.Shared.Models;

namespace VideoGameLibary.Server.Data
{
    /// <summary>
    /// Information of data context
    /// CreatedBy:ThiepTT(18/09/2023)
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