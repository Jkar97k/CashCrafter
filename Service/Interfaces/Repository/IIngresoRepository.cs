using CashCrafter.DTO;

namespace CashCrafter.Service
{
    public interface IIngresoRepository
    {
        Task<int> Create(PostIngresosDTO dto);
        Task<int> Delete(int id);
        Task<List<IngresosDTO>> Get();
        Task<IngresosDTO> GetById(int Id);
        Task<int> Update(int id, PostIngresosDTO dto);
    }
}