using AutoMapper;
using CashCrafter.Api.Context;
using CashCrafter.Api.DTO;
using CashCrafter.Api.Interfaces;
using CashCrafter.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace CashCrafter.Api.Repository
{
    public class IngresoRepository : IIngresoRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public IngresoRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<IngresosDTO>> Get()
        {
            var data = await _context.Ingresos.ToListAsync();
            var dto = _mapper.Map<List<IngresosDTO>>(data);
            return dto;
        }
        public async Task<IngresosDTO> GetById(int Id)
        {
            var data = await _context.Ingresos.FirstOrDefaultAsync(x => x.Id == Id);
            var dto = _mapper.Map<IngresosDTO>(data);
            return dto;
        }

        public async Task<int> Create(PostIngresosDTO dto)
        {
            var data = _mapper.Map<Ingreso>(dto);
            _context.Add(data);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Update(int id, PostIngresosDTO dto)
        {
            var data = await _context.Ingresos.FirstOrDefaultAsync(x => x.Id == id);
            _mapper.Map(dto, data);
            _context.Update(data);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int id)
        {
            var data = await _context.Ingresos.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(data);
            return await _context.SaveChangesAsync();
        }
    }
}
