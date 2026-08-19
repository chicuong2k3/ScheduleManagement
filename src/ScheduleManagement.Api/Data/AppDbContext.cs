namespace ScheduleManagement.Api.Data;

using Microsoft.EntityFrameworkCore;
using ScheduleManagement.Api.Models;
// coding agents: codex, opencode, openclaude
// model: deepseek, gemini
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Student> Students { get; set; } = null!; // property
}