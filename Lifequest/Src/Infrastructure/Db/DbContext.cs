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

  public DbSet<SecurityAccountTable> SecurityAccountTable {get; set;}

  public DbSet<SecurityAccountAmmountTable> SecurityAccountAmmountTable {get;set;}

  public DbSet<FixedCostTable> FixedCostTable {get; set;}

  public DbSet<BankCategoriesMst> BankCategoriesMstTable {get; set;}

  public DbSet<ExpenseAndIncomeTable> ExpenseAndIncomeTable{get; set;}

  public DbSet<ExpenseAndIncomeLargeCategoryMasterTable> ExpenseAndIncomeLargeCategoryMasterTable{get;set;}

  public DbSet<ExpenseAndIncomeSmallCategoryMasterTable> ExpenseAndIncomeSmallCategoryMasterTable{get;set;}
  readonly MySqlServerVersion serverVersion = new (new Version(5, 7, 0));
  public LifequestDbContext(DbContextOptions<LifequestDbContext> oprions) : base (oprions)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<ExpenseAndIncomeLargeCategoryMasterTable>().HasData(
      new ExpenseAndIncomeLargeCategoryMasterTable
      {
        Id = 1,
        LargeCategoryName = "食費"
      },
      new ExpenseAndIncomeLargeCategoryMasterTable
      {
        Id = 2,
        LargeCategoryName = "日用雑貨"
      },
      new ExpenseAndIncomeLargeCategoryMasterTable
      {
        Id = 3,
        LargeCategoryName = "交通"
      },
      new ExpenseAndIncomeLargeCategoryMasterTable
      {
        Id = 4,
        LargeCategoryName = "交際費"
      },
      new ExpenseAndIncomeLargeCategoryMasterTable
      {
        Id = 5,
        LargeCategoryName = "エンタメ"
      },
      new ExpenseAndIncomeLargeCategoryMasterTable
      {
        Id = 6,
        LargeCategoryName = "教育・教養"
      },
      new ExpenseAndIncomeLargeCategoryMasterTable
      {
        Id = 7,
        LargeCategoryName = "美容・服"
      },
      new ExpenseAndIncomeLargeCategoryMasterTable
      {
        Id = 8,
        LargeCategoryName = "医療・保険"
      },
      new ExpenseAndIncomeLargeCategoryMasterTable
      {
        Id = 9,
        LargeCategoryName = "通信"
      },
      new ExpenseAndIncomeLargeCategoryMasterTable
      {
        Id = 10,
        LargeCategoryName = "水道・光熱費"
      },
      new ExpenseAndIncomeLargeCategoryMasterTable
      {
        Id = 11,
        LargeCategoryName = "住まい"
      },
      new ExpenseAndIncomeLargeCategoryMasterTable
      {
        Id = 12,
        LargeCategoryName = "車"
      },
      new ExpenseAndIncomeLargeCategoryMasterTable
      {
        Id = 13,
        LargeCategoryName = "税金"
      },
      new ExpenseAndIncomeLargeCategoryMasterTable
      {
        Id = 14,
        LargeCategoryName = "大型出費"
      },
      new ExpenseAndIncomeLargeCategoryMasterTable
      {
        Id = 15,
        LargeCategoryName = "その他"
      }
    );

    modelBuilder.Entity<ExpenseAndIncomeSmallCategoryMasterTable>().HasData(
      // 食費
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 1,
        ExpenseAndIncomeLargeCategoryId = 1,
        SmallCategoryName = "食料品",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 2,
        ExpenseAndIncomeLargeCategoryId = 1,
        SmallCategoryName = "カフェ",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 3,
        ExpenseAndIncomeLargeCategoryId = 1,
        SmallCategoryName = "朝ご飯",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 4,
        ExpenseAndIncomeLargeCategoryId = 1,
        SmallCategoryName = "昼ご飯",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 5,
        ExpenseAndIncomeLargeCategoryId = 1,
        SmallCategoryName = "晩ご飯",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 6,
        ExpenseAndIncomeLargeCategoryId = 1,
        SmallCategoryName = "その他",
      },
      // 日用雑貨
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 7,
        ExpenseAndIncomeLargeCategoryId = 2,
        SmallCategoryName = "消耗品",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 8,
        ExpenseAndIncomeLargeCategoryId = 2,
        SmallCategoryName = "子ども関連",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 9,
        ExpenseAndIncomeLargeCategoryId = 2,
        SmallCategoryName = "ペット関連",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 10,
        ExpenseAndIncomeLargeCategoryId = 2,
        SmallCategoryName = "タバコ",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 11,
        ExpenseAndIncomeLargeCategoryId = 2,
        SmallCategoryName = "その他",
      },
      // 交通
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 12,
        ExpenseAndIncomeLargeCategoryId = 3,
        SmallCategoryName = "電車",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 13,
        ExpenseAndIncomeLargeCategoryId = 3,
        SmallCategoryName = "タクシー",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 14,
        ExpenseAndIncomeLargeCategoryId = 3,
        SmallCategoryName = "バス",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 15,
        ExpenseAndIncomeLargeCategoryId = 3,
        SmallCategoryName = "飛行機",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 16,
        ExpenseAndIncomeLargeCategoryId = 3,
        SmallCategoryName = "その他",
      },
    // 交際費
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 17,
        ExpenseAndIncomeLargeCategoryId = 4,
        SmallCategoryName = "飲み会",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 18,
        ExpenseAndIncomeLargeCategoryId = 4,
        SmallCategoryName = "プレゼント",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 19,
        ExpenseAndIncomeLargeCategoryId = 4,
        SmallCategoryName = "ご祝儀・香典",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 20,
        ExpenseAndIncomeLargeCategoryId = 4,
        SmallCategoryName = "その他",
      },
      // エンタメ
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 21,
        ExpenseAndIncomeLargeCategoryId = 5,
        SmallCategoryName = "レジャー",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 22,
        ExpenseAndIncomeLargeCategoryId = 5,
        SmallCategoryName = "イベント",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 23,
        ExpenseAndIncomeLargeCategoryId = 5,
        SmallCategoryName = "映画・動画",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 24,
        ExpenseAndIncomeLargeCategoryId = 5,
        SmallCategoryName = "音楽",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 25,
        ExpenseAndIncomeLargeCategoryId = 5,
        SmallCategoryName = "漫画",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 26,
        ExpenseAndIncomeLargeCategoryId = 5,
        SmallCategoryName = "書籍",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 27,
        ExpenseAndIncomeLargeCategoryId = 5,
        SmallCategoryName = "ゲーム",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 28,
        ExpenseAndIncomeLargeCategoryId = 5,
        SmallCategoryName = "その他",
      },
      //教育・教養
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 29,
        ExpenseAndIncomeLargeCategoryId = 6,
        SmallCategoryName = "習い事",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 30,
        ExpenseAndIncomeLargeCategoryId = 6,
        SmallCategoryName = "新聞",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 31,
        ExpenseAndIncomeLargeCategoryId = 6,
        SmallCategoryName = "参考書",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 32,
        ExpenseAndIncomeLargeCategoryId = 6,
        SmallCategoryName = "受験料",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 33,
        ExpenseAndIncomeLargeCategoryId = 6,
        SmallCategoryName = "学費",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 34,
        ExpenseAndIncomeLargeCategoryId = 6,
        SmallCategoryName = "学質保険",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 35,
        ExpenseAndIncomeLargeCategoryId = 6,
        SmallCategoryName = "塾",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 36,
        ExpenseAndIncomeLargeCategoryId = 6,
        SmallCategoryName = "その他",
      },
      // 美容・服
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 37,
        ExpenseAndIncomeLargeCategoryId = 7,
        SmallCategoryName = "洋服",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 38,
        ExpenseAndIncomeLargeCategoryId = 7,
        SmallCategoryName = "アクセサリー・小物",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 39,
        ExpenseAndIncomeLargeCategoryId = 7,
        SmallCategoryName = "下着",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 40,
        ExpenseAndIncomeLargeCategoryId = 7,
        SmallCategoryName = "ジム・健康",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 41,
        ExpenseAndIncomeLargeCategoryId = 7,
        SmallCategoryName = "美容院",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 42,
        ExpenseAndIncomeLargeCategoryId = 7,
        SmallCategoryName = "コスメ",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 43,
        ExpenseAndIncomeLargeCategoryId = 7,
        SmallCategoryName = "エスト・メイル",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 44,
        ExpenseAndIncomeLargeCategoryId = 7,
        SmallCategoryName = "クリーニング",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 45,
        ExpenseAndIncomeLargeCategoryId = 7,
        SmallCategoryName = "その他",
      },
      // 医療保険: 7
      // 通信: 8
      // 水道・高熱: 9
      // 住まい: 10
      // 車: 11
      // 税金: 12
      // 大型出費: 13
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 46,
        ExpenseAndIncomeLargeCategoryId = 14,
        SmallCategoryName = "旅行",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 47,
        ExpenseAndIncomeLargeCategoryId = 14,
        SmallCategoryName = "結婚",
      },
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 48,
        ExpenseAndIncomeLargeCategoryId = 14,
        SmallCategoryName = "その他",
      },
      // その他: 14
      new ExpenseAndIncomeSmallCategoryMasterTable{
        Id = 49,
        ExpenseAndIncomeLargeCategoryId = 15,
        SmallCategoryName = "その他",
      }
    );
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {

  }
}