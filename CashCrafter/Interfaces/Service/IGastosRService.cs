using CashCrafter.Api.DTO;

namespace CashCrafter.Api.Interfaces
{
    public interface IGastosRService:IMensaje
    {
        Task<int> Create(PostGastosRDTO dto);
        Task<int> Delete(int id);
        Task<List<GastoRDTO>> Get();
        Task<GastoRDTO> GetById(int id);
        Task<int> Update(int id, PutGastosRDTO dto);
    }
}