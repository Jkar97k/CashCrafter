using AutoMapper;
using CashCrafter.Api.Context;
using CashCrafter.Api.DTO;
using CashCrafter.Api.Interfaces;
using CashCrafter.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace CashCrafter.Repository
{
    public class UbicacionRepository : IUbicacionRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public UbicacionRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UbicacionDTO>> Get()
        {
            var data = await _context.Ubicaciones.ToListAsync();
            var dto = _mapper.Map<List<UbicacionDTO>>(data);
            return dto;
        }

        public async Task<UbicacionDTO> GetById(int Id)
        {
            var data = await _context.Ubicaciones.FirstOrDefaultAsync(x => x.Id == Id);
            var dto = _mapper.Map<UbicacionDTO>(data);
            return dto;
        }
        public async Task<UbicacionDTO> GetByName(string lugar)
        {
            var data = await _context.Ubicaciones.FirstOrDefaultAsync(x => x.Lugar == lugar);
            var dto = _mapper.Map<UbicacionDTO>(data);
            return dto;
        }
        public async Task<int> Create(PostUbicacionDTO dto)
        {
            var data = _mapper.Map<Ubicacion>(dto);
            _context.Add(data);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Update(int id, PostUbicacionDTO dto)
        {
            var data = await _context.Ubicaciones.FirstOrDefaultAsync(x => x.Id == id);
            
            _mapper.Map(dto, data);
            _context.Update(data);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int id)
        {
            var data = await _context.Ubicaciones.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(data);
            return await _context.SaveChangesAsync();
        }
    }
}
