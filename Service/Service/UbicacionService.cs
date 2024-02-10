using CashCrafter.DTO;

namespace CashCrafter.Service
{
    public class UbicacionService : Mensaje, IUbicacionService
    {
        private readonly IUbicacionRepository _ubicacionRepository;

        public UbicacionService(IUbicacionRepository ubicacionRepository)
        {
            _ubicacionRepository = ubicacionRepository;
        }
        public async Task<List<UbicacionDTO>> Get()
        {
            try
            {
                var dto = await _ubicacionRepository.Get();
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

        public async Task<UbicacionDTO> GetById(int id)
        {
            try
            {
                var dto = await _ubicacionRepository.GetById(id);
                if (dto == null)
                {
                    Informacion = "La ubicacion que intenta buscar no existe";
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

        public async Task<int> Create(PostUbicacionDTO dto)
        {
            try
            {
                var marca = await _ubicacionRepository.GetByName(dto.Lugar);
                if (marca != null)
                {
                    Informacion = "Esa ubicacion ya existe en base de datos";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _ubicacionRepository.Create(dto);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }
                Informacion = "Esa ubicacion ha sido Creada exitosamente";
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

        public async Task<int> Update(int id, PostUbicacionDTO dto)
        {
            try
            {
                var marca = await _ubicacionRepository.GetById(id);

                if (marca == null)
                {
                    Informacion = "La ubicacion para Actualizar no existe en base de datos";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _ubicacionRepository.Update(id, dto);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }
                Informacion = "La ubicacion ha sido Actualizada exitosamente";
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
                var marca = await _ubicacionRepository.GetById(id);

                if (marca == null)
                {
                    Informacion = "La ubicacion que intenta eliminar no existe";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _ubicacionRepository.Delete(id);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }

                Informacion = "La ubicacion ha sido eliminado exitosamente";
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
