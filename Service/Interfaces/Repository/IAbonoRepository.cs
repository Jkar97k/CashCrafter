using CashCrafter.DTO;

namespace CashCrafter.Service
{
    public interface IAbonoRepository
    {
        Task<int> Create(PostAbonoDTO dto);
        Task<int> Delete(int id);
        Task<List<AbonoDTO>> Get();
        Task<AbonoDTO> GetById(int Id);
        Task<int> Update(int id, PutAbonoDTO dto);
    }
}