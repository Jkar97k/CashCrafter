using CashCrafter.Api.DTO;

namespace CashCrafter.Api.Interfaces
{
    public interface ITipoIngresoRepository
    {
        Task<int> Create(PostTipoIngresoDTO dto);
        Task<int> Delete(int id);
        Task<List<TipoIngresoDTO>> Get();
        Task<TipoIngresoDTO> GetById(int Id);
        Task<TipoIngresoDTO> GetByName(string tipo);
        Task<int> Update(int id, PostTipoIngresoDTO dto);
    }
}