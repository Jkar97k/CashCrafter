using CashCrafter.DTO;


namespace CashCrafter.Service
{
    public class UserService : Mensaje, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDTO>> Get()
        {
            try
            {
                var dto = await _userRepository.Get();
                Informacion = "Consulta realizada con exito.";
                StatusCode = 200;
                return dto;

            }
            catch (Exception ex)
            {
                Informacion = ex.Message;
                StatusCode = 500;
                return null;
            }
        }

        public async Task<UserDTO> GetById(int id)
        {
            try
            {
                var dto = await _userRepository.GetById(id);
                if (dto == null)
                {
                    Informacion = "El Usuario que intenta buscar no existe";
                    StatusCode = 400;
                    return null;
                }
                Informacion = "Consulta realizada con exito.";
                StatusCode = 200;
                return dto;

            }
            catch (Exception ex)
            {
                Informacion = ex.Message;
                StatusCode = 500;
                return null;
            }
        }

        public async Task<int> Create(PostUserDTO dto)
        {
            try
            {
                var marca = await _userRepository.GetByName(dto.NickName);
                if (marca != null)
                {
                    Informacion = "Este nick ya existe en base de datos";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _userRepository.Create(dto);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }
                Informacion = "El usuario ha sido Creada exitosamente";
                StatusCode = 200;
                return 1;

            }
            catch (Exception ex)
            {
                Informacion = ex.Message;
                StatusCode = 500;
                return 0;
            }
        }

        public async Task<int> Update(int id, PutUserDTO dto)
        {
            try
            {
                var marca = await _userRepository.GetById(id);

                if (marca == null)
                {
                    Informacion = "El Usuario para Actualizar no existe en base de datos";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _userRepository.Update(id, dto);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }
                Informacion = "El Usuario ha sido Actualizada exitosamente";
                StatusCode = 200;
                return 1;
            }
            catch (Exception ex)
            {
                Informacion = ex.Message;
                StatusCode = 500;
                return 0;
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                var marca = await _userRepository.GetById(id);

                if (marca == null)
                {
                    Informacion = "El usuario que intenta eliminar no existe";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _userRepository.Delete(id);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }

                Informacion = "El usuario ha sido eliminado exitosamente";
                StatusCode = 200;
                return result;
            }
            catch (Exception ex)
            {
                Informacion = ex.Message;
                StatusCode = 500;
                return 0;
            }
        }
    }
}
