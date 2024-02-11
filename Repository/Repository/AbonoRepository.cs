using AutoMapper;
using CashCrafter.DTO;
using CashCrafter.Model;
using CashCrafter.Service;
using Microsoft.EntityFrameworkCore;


namespace CashCrafter.Repository
{
    public class AbonoRepository : IAbonoRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AbonoRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AbonoDTO>> Get()
        {
            var data = await _context.Abonos.ToListAsync();
            var dto = _mapper.Map<List<AbonoDTO>>(data);
            return dto;
        }
        public async Task<AbonoDTO> GetById(int Id)
        {
            var data = await _context.Abonos.FirstOrDefaultAsync(x => x.Id == Id);
            var dto = _mapper.Map<AbonoDTO>(data);
            return dto;
        }
        public async Task<int> Create(PostAbonoDTO dto)
        {
            var data = _mapper.Map<Abono>(dto);
            _context.Add(data);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Update(int id, PutAbonoDTO dto)
        {
            var data = await _context.Abonos.FirstOrDefaultAsync(x => x.Id == id);
            _mapper.Map(dto, data);
            _context.Update(data);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int id)
        {
            var data = await _context.Abonos.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(data);
            return await _context.SaveChangesAsync();
        }

    }
}
