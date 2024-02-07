using CashCrafter.Api.DTO;

namespace CashCrafter.Api.Interfaces
{
    public interface IUserRepository
    {
        Task<int> Create(PostUserDTO dto);
        Task<int> Delete(int id);
        Task<List<UserDTO>> Get();
        Task<UserDTO> GetById(int Id);
        Task<UserDTO> GetByName(string nick);
        Task<int> Update(int id, PutUserDTO dto);
    }
}