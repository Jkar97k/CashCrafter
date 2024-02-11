using CashCrafter.DTO;

namespace CashCrafter.Service
{
    public interface IClaseService:IMensaje
    {
        Task<int> Create(PostClaseDTO dto);
        Task<int> Delete(int id);
        Task<List<ClaseDTO>> Get();
        Task<ClaseDTO> GetById(int id);
        Task<int> Update(int id, PostClaseDTO dto);
    }
}