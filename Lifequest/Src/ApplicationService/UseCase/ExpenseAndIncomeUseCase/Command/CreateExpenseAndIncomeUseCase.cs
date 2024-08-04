using Lifequest.Src.Domain.IRepository;
using Lifequest.Src.Domain.Models.ExpenseAndIncome;

namespace Lifequest.Src.ApplicationService.UseCase.ExpenseAndIncomeUseCase.Command;

public class CreatexpenseAndIncomeUsecase
{
  private readonly IExpenseAndIncomeRepository _expenseAndIncomeRepository;

  public CreatexpenseAndIncomeUsecase(IExpenseAndIncomeRepository expenseAndIncomeRepository)
  {
    _expenseAndIncomeRepository = expenseAndIncomeRepository;
  }

  public async Task Invoke(CreateExpenseAndIncomeUseCaseCommand cm)
  {
    // 新しい値を作成
    var newValue = ExpenseAndIncome.Create(
      cm.FamilyId,
      cm.FamilymemberId,
      cm.ExpenseAndIncomeLargeCategoryId,
      cm.ExpenseAndIncomeSmallCategoryId,
      cm.Amount,
      cm.LargeCategoryName,
      cm.SmallCategoryName,
      cm.TargetDate,
      cm.IsExpense
    );

    // 永続化
    await _expenseAndIncomeRepository.Create(newValue);
  }
}