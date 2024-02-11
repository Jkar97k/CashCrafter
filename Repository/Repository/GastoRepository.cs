
using AutoMapper;
using CashCrafter.DTO;
using CashCrafter.Model;
using Microsoft.EntityFrameworkCore;
using CashCrafter.Service;

namespace CashCrafter.Repository
{
    public class GastoRepository : IGastoRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GastoRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GastoDTO>> Get()
        {
            var data = await _context.Gastos.ToListAsync();
            var dto = _mapper.Map<List<GastoDTO>>(data);
            return dto;
        }
        public async Task<GastoDTO> GetById(int Id)
        {
            var data = await _context.Gastos.FirstOrDefaultAsync(x => x.Id == Id);
            var dto = _mapper.Map<GastoDTO>(data);
            return dto;
        }
        public async Task<GastoDTO> GetByName(string Item)
        {
            var data = await _context.Gastos.FirstOrDefaultAsync(x => x.Item == Item);
            var dto = _mapper.Map<GastoDTO>(data);
            return dto;
        }
        public async Task<int> Create(PostGastoDTO dto)
        {
            var data = _mapper.Map<GastoR>(dto);
            _context.Add(data);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Update(int id, PutGastoDTO dto)
        {
            var data = await _context.Gastos.FirstOrDefaultAsync(x => x.Id == id);
            _mapper.Map(dto, data);
            _context.Update(data);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int id)
        {
            var data = await _context.Gastos.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(data);
            return await _context.SaveChangesAsync();
        }
    }
}
