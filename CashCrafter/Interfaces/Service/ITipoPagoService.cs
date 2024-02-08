using CashCrafter.Api.DTO;

namespace CashCrafter.Api.Interfaces
{
    public interface ITipoPagoService:IMensaje
    {
        Task<int> Create(PostTipoPagoDTO dto);
        Task<int> Delete(int id);
        Task<List<TipoPagoDTO>> Get();
        Task<TipoPagoDTO> GetById(int id);
        Task<int> Update(int id, PostTipoPagoDTO dto);
    }
}