using Microsoft.EntityFrameworkCore;
using Lifequest.Src.Infrastructure.Db.Tables;
namespace Lifequest.Src.Infrastructure.Db;

public class LifequestDbContext : DbContext
{
  public DbSet<UserTable> UserTable {get; set;}
  public DbSet<FamilyTable> FamilyTable {get; set;}
  public DbSet<FamilyMembersTable> FamilyMembersTable {get; set;}
  public DbSet<TaskTable> TaskTable {get; set;}

  public DbSet<ScheduleTable> ScheduleTable {get; set;}

  public DbSet<BankTable> BankTable {get; set;}

  public DbSet<BankHistoryTable> BankHistoryTable{get; set;}

  public DbSet<FixedCostTable> FixedCostTable {get; set;}
  readonly MySqlServerVersion serverVersion = new (new Version(5, 7, 0));
  public LifequestDbContext(DbContextOptions<LifequestDbContext> oprions) : base (oprions)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {

  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {

  }
}