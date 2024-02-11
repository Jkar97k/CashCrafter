using CashCrafter.DTO;

namespace CashCrafter.Service
{
    public interface IAbonoService:IMensaje
    {
        Task<int> Create(PostAbonoDTO dto);
        Task<int> Delete(int id);
        Task<List<AbonoDTO>> Get();
        Task<AbonoDTO> GetById(int id);
        Task<int> Update(int id, PutAbonoDTO dto);
    }
}