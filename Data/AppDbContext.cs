﻿using CrudApp.Models;
using Microsoft.EntityFrameworkCore;
namespace CrudApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<StudentInfo> Students { get; set; }
    }
}
