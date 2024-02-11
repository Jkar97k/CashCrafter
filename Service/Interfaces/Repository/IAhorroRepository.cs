using CashCrafter.DTO;

namespace CashCrafter.Service
{
    public interface IAhorroRepository
    {
        Task<int> Create(PostAhorroDTO dto);
        Task<int> Delete(int id);
        Task<List<AhorroDTO>> Get();
        Task<AhorroDTO> GetById(int Id);
        Task<int> Update(int id, PostAhorroDTO dto);
    }
}