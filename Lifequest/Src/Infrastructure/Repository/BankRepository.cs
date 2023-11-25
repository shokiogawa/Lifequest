using Lifequest.Src.Domain.Models.Banks;
using Lifequest.Src.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Infrastructure.Db.Tables;
using Lifequest.Src.Domain.Models.BankHistory;
namespace Lifequest.Src.Infrastructure.Repository;

public class BankRepository : IBankRepository
{
  private readonly LifequestDbContext _dbContext;
  private readonly IMapper _mapper;

  public BankRepository(LifequestDbContext dbContext, IMapper mapper)
  {
    _dbContext = dbContext;
    _mapper = mapper;
  }

  /// <summary>
  /// 家族が所有している銀行を取得
  /// </summary>
  /// <param name="familyId"></param>
  /// <returns></returns>
  public async Task<List<Bank>>  GetFamilyBanks(uint familyId)
  {
    var query = from banks in _dbContext.BankTable where 
                     banks.FamilyId == familyId && 
                     banks.DeletedAt == Constant.DeletedAt
                     orderby banks.OrderNumber ascending
                     select banks;

    var bankDataList = await query.ToListAsync();
    var bank = bankDataList.Select( _  => {
      var bankInfo = BankInfo.Reconstruct(_.Name, _.Code ?? "", _.BranchNumber ?? default, _.BranchName ?? "", _.AccountNumber ?? default, _.TotalAmount, _.CategoryName);
      return Bank.Reconstructor(
      _.Id, 
      _.FamilyId, 
      _.FamilymemberId,
      _.OrderNumber,
      bankInfo,
      _.DeletedAt, 
      _.CreatedAt, 
      _.UpdatedAt
      );
    })
      .ToList();
    return bank;
  }

  /// <summary>
  /// 家族に紐づく銀行を作成する
  /// </summary>
  /// <param name="bank"></param>
  /// <returns></returns>
  public async Task Create(Bank bank)
  {
    try
    {
      var bankData = new BankTable
      {
        FamilyId = bank.FamilyId,
        FamilymemberId = bank.FamilymemberId,
        Name = bank.BankInfo.Name,
        Code = bank.BankInfo.Code,
        BranchName = bank.BankInfo.BranchName,
        BranchNumber = bank.BankInfo.BranchNumber,
        AccountNumber = bank.BankInfo.AccountNumber,
        TotalAmount = bank.BankInfo.TotalAmount,
      };
      await _dbContext.BankTable.AddAsync(bankData);
      var affectedRow = await _dbContext.SaveChangesAsync();
      if(affectedRow <= 0)
      {
        throw new Exception("bank data can not be saved");
        }
      }
    catch(Exception e)
    {
      throw e;
    }
  }

  /// <summary>
  /// 銀行情報を更新する
  /// </summary>
  /// <param name="newBank"></param>
  /// <returns></returns>
  public async Task UpdateInfo(Bank newBank)
  {
    try
    {
      var targetBank = await (from banks in _dbContext.BankTable where banks.Id == newBank.Id select banks).FirstOrDefaultAsync();
      if(targetBank == null)
      {
        throw new Exception("対象データが存在しません。");
      }
      // 対象データ更新
      targetBank.Name = newBank.BankInfo.Name;
      targetBank.Code = newBank.BankInfo.Code;
      targetBank.BranchName = newBank.BankInfo.BranchName;
      targetBank.BranchNumber = newBank.BankInfo.BranchNumber;
      targetBank.AccountNumber = newBank.BankInfo.AccountNumber;
      targetBank.CategoryName = newBank.BankInfo.CategoryName;
      targetBank.TotalAmount = newBank.BankInfo.TotalAmount;      
      var affectedRoew = await _dbContext.SaveChangesAsync();
      if(affectedRoew <= 0)
      {
        throw new Exception("編集できませんでした。前後でデータ内容が変化しているか確認してください。");
      }
    }
    catch(Exception e)
    {
      throw e;
    }
  }

  /// <summary>
  /// 貯金額を更新する
  /// </summary>
  /// <param name="newBank"></param>
  /// <param name="bankHistory"></param>
  /// <returns></returns>
  public async Task UpdateTotalAmount(Bank newBank, BankHistory bankHistory)
  {
    using(var transaction = await _dbContext.Database.BeginTransactionAsync())
    {
      try
      {
        var targetBank = await (from banks in _dbContext.BankTable where banks.Id == newBank.Id select banks).FirstOrDefaultAsync();
        if(targetBank == null)
        {
          throw new Exception("対象データが存在しません。");
        }
        targetBank.TotalAmount = newBank.BankInfo.TotalAmount;

        var bankHistoryData = _mapper.Map<BankHistoryTable>(bankHistory);
        await _dbContext.BankHistoryTable.AddAsync(bankHistoryData);
        await _dbContext.SaveChangesAsync();

        await transaction.CommitAsync();
      }
      catch(Exception e)
      {
        await transaction.RollbackAsync();
        throw e;
      } 
    }
  }

  /// <summary>
  /// 銀行IDをもとに銀行情報を取得する
  /// </summary>
  /// <param name="bankId"></param>
  /// <returns></returns>
  public async Task<Bank?> FetchByIdAsync(uint bankId)
  {
    var query = from banks in _dbContext.BankTable where banks.Id == bankId select banks;
    var bank = await query.FirstOrDefaultAsync();
    return bank != null ?  Bank.Reconstructor(
      bank.Id, 
      bank.FamilyId, 
      bank.FamilymemberId, 
      bank.OrderNumber,
      BankInfo.Reconstruct(
        bank.Name, 
        bank.Code ?? "", 
        bank.BranchNumber ?? default, 
        bank.BranchName ?? "", 
        bank.AccountNumber ?? default, 
        bank.TotalAmount,
        bank.CategoryName
      ),
      bank.DeletedAt, 
      bank.CreatedAt, 
      bank.UpdatedAt) : null;
  }

  /// <summary>
  /// 家族に紐づく銀行情報を取得する
  /// </summary>
  /// <param name="familyId"></param>
  /// <returns></returns>
  public async Task<List<Bank>> FetchListByFamilyId(uint familyId)
  {
    try
    {
      var query = from banks in _dbContext.BankTable where 
                  banks.FamilyId == familyId && 
                  banks.DeletedAt == Constant.DeletedAt
                  orderby banks.OrderNumber ascending 
                  select banks;
                  
      var bankDataList = await query.ToListAsync();
      var bankList = bankDataList.Select(bank => 
      {
        return Bank.Reconstructor(
        bank.Id, 
        bank.FamilyId, 
        bank.FamilymemberId,
        bank.OrderNumber,
        BankInfo.Reconstruct(
          bank.Name, 
          bank.Code ?? "", 
          bank.BranchNumber ?? default, 
          bank.BranchName ?? "", 
          bank.AccountNumber ?? default, 
          bank.TotalAmount,
          bank.CategoryName
          ),
        bank.DeletedAt, 
        bank.CreatedAt, 
        bank.UpdatedAt
      );
      }).ToList();
      return bankList;
    }
    catch(Exception ex)
    {
      throw ex;
    }
  }

}