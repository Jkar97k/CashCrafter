using AutoMapper;
using CashCrafter.Api.Context;
using CashCrafter.Api.DTO;
using CashCrafter.Api.Interfaces;
using CashCrafter.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace CashCrafter.Repository
{
    public class TipoAhorroRepository : ITipoAhorroRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public TipoAhorroRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TipoAhorroDTO>> Get()
        {
            var data = await _context.TiposAhorro.ToListAsync();
            var dto = _mapper.Map<List<TipoAhorroDTO>>(data);
            return dto;
        }
        public async Task<TipoAhorroDTO> GetById(int Id)
        {
            var data = await _context.TiposAhorro.FirstOrDefaultAsync(x => x.Id == Id);
            var dto = _mapper.Map<TipoAhorroDTO>(data);
            return dto;
        }
        public async Task<TipoAhorroDTO> GetByName(string nick)
        {
            var data = await _context.TiposAhorro.FirstOrDefaultAsync(x => x.Nombre == nick);
            var dto = _mapper.Map<TipoAhorroDTO>(data);
            return dto;
        }
        public async Task<int> Create(PostTipoAhorroDTO dto)
        {
            var data = _mapper.Map<TipoAhorro>(dto);
            _context.Add(data);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Update(int id, PostTipoAhorroDTO dto)
        {
            var data = await _context.TiposAhorro.FirstOrDefaultAsync(x => x.Id == id);
            _mapper.Map(dto, data);
            _context.Update(data);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int id)
        {
            var data = await _context.TiposAhorro.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(data);
            return await _context.SaveChangesAsync();
        }
    }
}
