using CashCrafter.DTO;

namespace CashCrafter.Service
{
    internal interface IGastosService:IMensaje
    {
        Task<int> Create(PostGastoDTO dto);
        Task<int> Delete(int id);
        Task<List<GastoDTO>> Get();
        Task<GastoDTO> GetById(int id);
        Task<int> Update(int id, PutGastosRDTO dto);
    }
}
