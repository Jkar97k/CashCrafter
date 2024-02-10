using AutoMapper;
using CashCrafter.DTO;
using CashCrafter.Model;
using CashCrafter.Service;
using Microsoft.EntityFrameworkCore;

namespace CashCrafter.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public UserRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> Get()
        {
            var data = await _context.Users.ToListAsync();
            var dto = _mapper.Map<List<UserDTO>>(data);
            return dto;
        }
        public async Task<UserDTO> GetById(int Id)
        {
            var data = await _context.Users.FirstOrDefaultAsync(x => x.Id == Id);
            var dto = _mapper.Map<UserDTO>(data);
            return dto;
        }
        public async Task<UserDTO> GetByName(string nick)
        {
            var data = await _context.Users.FirstOrDefaultAsync(x => x.NickName == nick);
            var dto = _mapper.Map<UserDTO>(data);
            return dto;
        }
        public async Task<int> Create(PostUserDTO dto)
        {
            var data = _mapper.Map<User>(dto);
            _context.Add(data);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Update(int id, PutUserDTO dto)
        {
            var data = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            _mapper.Map(dto, data);
            _context.Update(data);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int id)
        {
            var data = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(data);
            return await _context.SaveChangesAsync();
        }
    }
}
