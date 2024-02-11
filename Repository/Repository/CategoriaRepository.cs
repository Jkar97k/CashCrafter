using AutoMapper;
using CashCrafter.DTO;
using CashCrafter.Model;
using CashCrafter.Service;
using Microsoft.EntityFrameworkCore;



namespace CashCrafter.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CategoriaRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CategoriaDTO>> Get()
        {
            var data = await _context.Categorias.ToListAsync();
            var dto = _mapper.Map<List<CategoriaDTO>>(data);
            return dto;
        }
        public async Task<CategoriaDTO> GetById(int Id)
        {
            var data = await _context.Categorias.FirstOrDefaultAsync(x => x.Id == Id);
            var dto = _mapper.Map<CategoriaDTO>(data);
            return dto;
        }
        public async Task<CategoriaDTO> GetByName(string Item)
        {
            var data = await _context.Categorias.FirstOrDefaultAsync(x => x.Nombre == Item);
            var dto = _mapper.Map<CategoriaDTO>(data);
            return dto;
        }
        public async Task<int> Create(PostCategoriaDTO dto)
        {
            var data = _mapper.Map<Categoria>(dto);
            _context.Add(data);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Update(int id, PostCategoriaDTO dto)
        {
            var data = await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);
            _mapper.Map(dto, data);
            _context.Update(data);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int id)
        {
            var data = await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(data);
            return await _context.SaveChangesAsync();
        }

    }
}
