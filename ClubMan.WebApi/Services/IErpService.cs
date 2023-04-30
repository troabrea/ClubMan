using ClubMan.Shared.Dto;

namespace ClubMan.WebApi.Services;

public interface IErpService
{
    Task<List<FacturaDto>> GetFacturasPendinetesAsync(long socioId);
}