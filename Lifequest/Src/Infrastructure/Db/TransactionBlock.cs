using Microsoft.EntityFrameworkCore;
namespace Lifequest.Src.Infrastructure.Db;

public class TransactionBlocks
{
  private readonly ILogger<TransactionBlocks> _logger;

  public TransactionBlocks(ILogger<TransactionBlocks> logger)
  {
    _logger = logger;
  }

  public async Task ExcutedBlock<TDbContext>(TDbContext dbContext, Func<TDbContext, Task<bool>> action) where TDbContext : DbContext
  {
    _logger.LogInformation("データベースに対するトランザクションを開始しました。");
    using (var transaction = dbContext.Database.BeginTransaction())
    {
      try
      {
        if(await action(dbContext))
        {
          _logger.LogInformation("データベースに対する操作がコミットされます。");
          await transaction.CommitAsync();
        }
        else
        {
          _logger.LogInformation("データベースに対する操作がロールバックされました。");
          await transaction.RollbackAsync();
        }
      }catch(Exception)
      {
        await transaction.RollbackAsync();
        _logger.LogCritical("データベーストランザクションでエラーが発生しました。操作はロールバックされました。");
        throw;
      }
    }

  }

}