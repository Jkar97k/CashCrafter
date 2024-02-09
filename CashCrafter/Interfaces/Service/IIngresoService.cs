using CashCrafter.Api.DTO;

namespace CashCrafter.Api.Interfaces
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