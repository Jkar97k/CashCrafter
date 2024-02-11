using CashCrafter.DTO;

namespace CashCrafter.Service
{
    public interface ICategoriaRepository
    {
        Task<int> Create(PostCategoriaDTO dto);
        Task<int> Delete(int id);
        Task<List<CategoriaDTO>> Get();
        Task<CategoriaDTO> GetById(int Id);
        Task<CategoriaDTO> GetByName(string Item);
        Task<int> Update(int id, PostCategoriaDTO dto);
    }
}