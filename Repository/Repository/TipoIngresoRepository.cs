using AutoMapper;
using CashCrafter.DTO;
using CashCrafter.Model;
using CashCrafter.Service;
using Microsoft.EntityFrameworkCore;

namespace CashCrafter.Repository
{
    public class TipoIngresoRepository : ITipoIngresoRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public TipoIngresoRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<TipoIngresoDTO>> Get()
        {
            var data = await _context.TiposIngresos.ToListAsync();
            var dto = _mapper.Map<List<TipoIngresoDTO>>(data);
            return dto;
        }
        public async Task<TipoIngresoDTO> GetById(int Id)
        {
            var data = await _context.TiposIngresos.FirstOrDefaultAsync(x => x.Id == Id);
            var dto = _mapper.Map<TipoIngresoDTO>(data);
            return dto;
        }
        public async Task<TipoIngresoDTO> GetByName(string tipo)
        {
            var data = await _context.TiposIngresos.FirstOrDefaultAsync(x => x.Tipo == tipo);
            var dto = _mapper.Map<TipoIngresoDTO>(data);
            return dto;
        }
        public async Task<int> Create(PostTipoIngresoDTO dto)
        {
            var data = _mapper.Map<TipoIngreso>(dto);
            _context.Add(data);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Update(int id, PostTipoIngresoDTO dto)
        {
            var data = await _context.TiposIngresos.FirstOrDefaultAsync(x => x.Id == id);
            _mapper.Map(dto, data);
            _context.Update(data);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int id)
        {
            var data = await _context.TiposIngresos.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(data);
            return await _context.SaveChangesAsync();
        }
    }
}
