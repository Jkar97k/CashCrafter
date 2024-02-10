using AutoMapper;
using CashCrafter.Api.Context;
using CashCrafter.Api.DTO;
using CashCrafter.Api.Interfaces;
using CashCrafter.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace CashCrafter.Api.Repository
{
    public class GastosrRepository : IGastosrRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GastosrRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GastoRDTO>> Get()
        {
            var data = await _context.GastosR.ToListAsync();
            var dto = _mapper.Map<List<GastoRDTO>>(data);
            return dto;
        }
        public async Task<GastoRDTO> GetById(int Id)
        {
            var data = await _context.GastosR.FirstOrDefaultAsync(x => x.Id == Id);
            var dto = _mapper.Map<GastoRDTO>(data);
            return dto;
        }
        public async Task<GastoRDTO> GetByName(string Item)
        {
            var data = await _context.GastosR.FirstOrDefaultAsync(x => x.Item == Item);
            var dto = _mapper.Map<GastoRDTO>(data);
            return dto;
        }
        public async Task<int> Create(PostGastosRDTO dto)
        {
            var data = _mapper.Map<GastoR>(dto);
            _context.Add(data);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Update(int id, PutGastosRDTO dto)
        {
            var data = await _context.GastosR.FirstOrDefaultAsync(x => x.Id == id);
            _mapper.Map(dto, data);
            _context.Update(data);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int id)
        {
            var data = await _context.GastosR.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(data);
            return await _context.SaveChangesAsync();
        }
    }
}
