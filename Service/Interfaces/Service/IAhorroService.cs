using CashCrafter.DTO;

namespace CashCrafter.Service
{
    public interface IAhorroService:IMensaje
    {
        Task<int> Create(PostAhorroDTO dto);
        Task<int> Delete(int id);
        Task<List<AhorroDTO>> Get();
        Task<AhorroDTO> GetById(int id);
        Task<int> Update(int id, PostAhorroDTO dto);
    }
}