﻿using CashCrafter.Api.DTO;

namespace CashCrafter.Api.Interfaces
{
    public interface ITipoAhorroRepository
    {
        Task<int> Create(PostTipoAhorroDTO dto);
        Task<int> Delete(int id);
        Task<List<TipoAhorroDTO>> Get();
        Task<TipoAhorroDTO> GetById(int Id);
        Task<TipoAhorroDTO> GetByName(string nick);
        Task<int> Update(int id, PostTipoAhorroDTO dto);
    }
}