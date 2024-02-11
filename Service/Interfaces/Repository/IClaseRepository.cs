using CashCrafter.DTO;

namespace CashCrafter.Service
{
    public interface IClaseRepository
    {
        Task<int> Create(PostClaseDTO dto);
        Task<int> Delete(int id);
        Task<List<ClaseDTO>> Get();
        Task<ClaseDTO> GetById(int Id);
        Task<ClaseDTO> GetByName(string Item);
        Task<int> Update(int id, PostClaseDTO dto);
    }
}