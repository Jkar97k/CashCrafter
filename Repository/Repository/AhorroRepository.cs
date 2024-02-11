using AutoMapper;
using CashCrafter.DTO;
using CashCrafter.Model;
using CashCrafter.Service;
using Microsoft.EntityFrameworkCore;

namespace CashCrafter.Repository
{
    public class AhorroRepository : IAhorroRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public AhorroRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<AhorroDTO>> Get()
        {
            var data = await _context.Ahorros.ToListAsync();
            var dto = _mapper.Map<List<AhorroDTO>>(data);
            return dto;
        }


        public async Task<AhorroDTO> GetById(int Id)
        {
            var data = await _context.Ahorros.FirstOrDefaultAsync(x => x.Id == Id);
            var dto = _mapper.Map<AhorroDTO>(data);
            return dto;
        }

        public async Task<int> Create(PostAhorroDTO dto)
        {
            var data = _mapper.Map<Ahorro>(dto);
            _context.Add(data);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Update(int id, PostAhorroDTO dto)
        {
            var data = await _context.Ahorros.FirstOrDefaultAsync(x => x.Id == id);
            _mapper.Map(dto, data);
            _context.Update(data);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int id)
        {
            var data = await _context.Ahorros.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(data);
            return await _context.SaveChangesAsync();
        }
    }
}
