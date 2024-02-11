using CashCrafter.DTO;

namespace CashCrafter.Service
{
    public interface IGastoRepository
    {
        Task<int> Create(PostGastoDTO dto);
        Task<int> Delete(int id);
        Task<List<GastoDTO>> Get();
        Task<GastoDTO> GetById(int Id);
        Task<GastoDTO> GetByName(string Item);
        Task<int> Update(int id, PutGastoDTO dto);
    }
}