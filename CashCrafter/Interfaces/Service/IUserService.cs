﻿using CashCrafter.Api.DTO;

namespace CashCrafter.Api.Interfaces
{
    public interface IUserService : IMensaje
    {
        Task<int> Create(PostUserDTO dto);
        Task<int> Delete(int id);
        Task<List<UserDTO>> Get();
        Task<UserDTO> GetById(int id);
        Task<int> Update(int id, PutUserDTO dto);
    }
}