using CashCrafter.DTO;

namespace CashCrafter.Service
{
    public interface ICategoriaService:IMensaje
    {
        Task<int> Create(PostCategoriaDTO dto);
        Task<int> Delete(int id);
        Task<List<CategoriaDTO>> Get();
        Task<CategoriaDTO> GetById(int id);
        Task<int> Update(int id, PostCategoriaDTO dto);
    }
}