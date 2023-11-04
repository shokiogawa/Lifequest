using Lifequest.Src.ApplicationService.UseCase.FamilyUseCase;

namespace Lifequest.Src.ApplicationService.IQueryService;
public interface IFamilyQueryService
{
  Task<List<FetchFamilyListUseCaseDto>> GetList(string uuid);
}