using CashCrafter.Api.DTO;

namespace CashCrafter.Api.Interfaces
{
    public interface IUbicacionRepository
    {
        Task<int> Create(PostUbicacionDTO dto);
        Task<int> Delete(int id);
        Task<List<UbicacionDTO>> Get();
        Task<UbicacionDTO> GetById(int Id);
        Task<UbicacionDTO> GetByName(string lugar);
        Task<int> Update(int id, PostUbicacionDTO dto);
    }
}