using Lifequest.Src.ApplicationService.UseCase.FamilyUseCase.Query;

namespace Lifequest.Src.ApplicationService.IQueryService;
public interface IFamilyQueryService
{
  Task<List<FetchFamilyListUseCaseDto>> FetchListByUuid(string uuid);
  Task<List<FetchFamilyListUseCaseDto>> FetchListByUserId(uint userId);
}