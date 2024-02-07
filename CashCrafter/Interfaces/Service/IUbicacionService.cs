using CashCrafter.Api.DTO;

namespace CashCrafter.Api.Interfaces
{
    public interface IUbicacionService:IMensaje
    {
        Task<int> Create(PostUbicacionDTO dto);
        Task<int> Delete(int id);
        Task<List<UbicacionDTO>> Get();
        Task<UbicacionDTO> GetById(int id);
        Task<int> Update(int id, PostUbicacionDTO dto);
    }
}