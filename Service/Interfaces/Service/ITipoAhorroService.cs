﻿using CashCrafter.DTO;

namespace CashCrafter.Service
{
    public interface ITipoAhorroService:IMensaje
    {
        Task<int> Create(PostTipoAhorroDTO dto);
        Task<int> Delete(int id);
        Task<List<TipoAhorroDTO>> Get();
        Task<TipoAhorroDTO> GetById(int id);
        Task<int> Update(int id, PostTipoAhorroDTO dto);
    }
}