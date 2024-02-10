using CashCrafter.DTO;

namespace CashCrafter.Service
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