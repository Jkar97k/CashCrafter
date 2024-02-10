using CashCrafter.DTO;

namespace CashCrafter.Service
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