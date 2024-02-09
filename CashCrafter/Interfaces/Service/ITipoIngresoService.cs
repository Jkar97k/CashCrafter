using CashCrafter.Api.DTO;

namespace CashCrafter.Api.Interfaces
{
    public interface ITipoIngresoService:IMensaje
    {
        Task<int> Create(PostTipoIngresoDTO dto);
        Task<int> Delete(int id);
        Task<List<TipoIngresoDTO>> Get();
        Task<TipoIngresoDTO> GetById(int id);
        Task<int> Update(int id, PostTipoIngresoDTO dto);
    }
}