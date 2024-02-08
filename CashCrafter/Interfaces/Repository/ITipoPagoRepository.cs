using CashCrafter.Api.DTO;

namespace CashCrafter.Api.Interfaces
{
    public interface ITipoPagoRepository
    {
        Task<int> Create(PostTipoPagoDTO dto);
        Task<int> Delete(int id);
        Task<List<TipoPagoDTO>> Get();
        Task<TipoPagoDTO> GetById(int Id);
        Task<TipoPagoDTO> GetByName(string nombre);
        Task<int> Update(int id, PostTipoPagoDTO dto);
    }
}