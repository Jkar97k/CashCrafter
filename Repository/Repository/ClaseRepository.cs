using AutoMapper;
using CashCrafter.DTO;
using CashCrafter.Model;
using CashCrafter.Repository;
using Microsoft.EntityFrameworkCore;


namespace CashCrafter.Service
{
    public class ClaseRepository : IClaseRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ClaseRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ClaseDTO>> Get()
        {
            var data = await _context.Clases.ToListAsync();
            var dto = _mapper.Map<List<ClaseDTO>>(data);
            return dto;
        }
        public async Task<ClaseDTO> GetById(int Id)
        {
            var data = await _context.Clases.FirstOrDefaultAsync(x => x.Id == Id);
            var dto = _mapper.Map<ClaseDTO>(data);
            return dto;
        }
        public async Task<ClaseDTO> GetByName(string Item)
        {
            var data = await _context.Clases.FirstOrDefaultAsync(x => x.Nom == Item);
            var dto = _mapper.Map<ClaseDTO>(data);
            return dto;
        }
        public async Task<int> Create(PostClaseDTO dto)
        {
            var data = _mapper.Map<Clase>(dto);
            _context.Add(data);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Update(int id, PostClaseDTO dto)
        {
            var data = await _context.Clases.FirstOrDefaultAsync(x => x.Id == id);
            _mapper.Map(dto, data);
            _context.Update(data);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int id)
        {
            var data = await _context.Clases.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(data);
            return await _context.SaveChangesAsync();
        }
    }
}
