using AutoMapper;
using CashCrafter.Api.Context;
using CashCrafter.Api.DTO;
using CashCrafter.Api.Interfaces;
using CashCrafter.Api.Model;
using Microsoft.EntityFrameworkCore;
namespace CashCrafter.Repository
{
    public class TipoPagoRepository : ITipoPagoRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public TipoPagoRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TipoPagoDTO>> Get()
        {
            var data = await _context.TiposPago.ToListAsync();
            var dto = _mapper.Map<List<TipoPagoDTO>>(data);
            return dto;
        }
        public async Task<TipoPagoDTO> GetById(int Id)
        {
            var data = await _context.TiposPago.FirstOrDefaultAsync(x => x.Id == Id);
            var dto = _mapper.Map<TipoPagoDTO>(data);
            return dto;
        }

        public async Task<TipoPagoDTO> GetByName(string nombre)
        {
            var data = await _context.TiposPago.FirstOrDefaultAsync(x => x.Nombre == nombre);
            var dto = _mapper.Map<TipoPagoDTO>(data);
            return dto;
        }
        public async Task<int> Create(PostTipoPagoDTO dto)
        {
            var data = _mapper.Map<TipoPago>(dto);
            _context.Add(data);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Update(int id, PostTipoPagoDTO dto)
        {
            var data = await _context.TiposPago.FirstOrDefaultAsync(x => x.Id == id);
            _mapper.Map(dto, data);
            _context.Update(data);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int id)
        {
            var data = await _context.TiposPago.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(data);
            return await _context.SaveChangesAsync();
        }

    }
}
