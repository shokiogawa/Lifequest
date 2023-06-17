using Lifequest.Src.Domain.Entity;
using Lifequest.Src.Infrastructure.Db;
namespace Lifequest.Src.Domain.IRepository;

public interface IBankRepository
{
  Task Create(Bank bank);
  Task UpdateInfo(Bank bank);
  Task UpdateTotalAmount(Bank newBank, BankHistory nabkHistory);
  Task<Bank?> GetByIdAsync(uint bankId);
}