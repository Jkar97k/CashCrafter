using CashCrafter.DTO;

namespace CashCrafter.Service
{
    public interface IIngresoService:IMensaje
    {
        Task<int> Create(PostIngresosDTO dto);
        Task<int> Delete(int id);
        Task<List<IngresosDTO>> Get();
        Task<IngresosDTO> GetById(int id);
        Task<int> Update(int id, PostIngresosDTO dto);
    }
}