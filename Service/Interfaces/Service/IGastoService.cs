using CashCrafter.DTO;

namespace CashCrafter.Service
{
    public interface IGastoService:IMensaje
    {
        Task<int> Create(PostGastoDTO dto);
        Task<int> Delete(int id);
        Task<List<GastoDTO>> Get();
        Task<GastoDTO> GetById(int id);
        Task<int> Update(int id, PutGastoDTO dto);
    }
}