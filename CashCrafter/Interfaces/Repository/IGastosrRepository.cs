using CashCrafter.Api.DTO;

namespace CashCrafter.Api.Interfaces
{
    public interface IGastosrRepository
    {
        Task<int> Create(PostGastosRDTO dto);
        Task<int> Delete(int id);
        Task<List<GastoRDTO>> Get();
        Task<GastoRDTO> GetById(int Id);
        Task<GastoRDTO> GetByName(string Item);
        Task<int> Update(int id, PutGastosRDTO dto);
    }
}