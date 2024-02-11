using CashCrafter.DTO;


namespace CashCrafter.Service
{
    public class ClaseService : Mensaje, IClaseService
    {
        private readonly IClaseRepository _claseService;

        public ClaseService(IClaseRepository claseService)
        {
            _claseService = claseService;
        }
        public async Task<List<ClaseDTO>> Get()
        {
            try
            {
                var dto = await _claseService.Get();
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

        public async Task<ClaseDTO> GetById(int id)
        {
            try
            {
                var dto = await _claseService.GetById(id);
                if (dto == null)
                {
                    Informacion = "El Gasto que intenta buscar no existe";
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

        public async Task<int> Create(PostClaseDTO dto)
        {
            try
            {
                var marca = await _claseService.GetByName(dto.Nom);
                if (marca != null)
                {
                    Informacion = "Este Gasto ya existe en base de datos";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _claseService.Create(dto);

                if (result == 0)
                {
                    Informacion = "La clase un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }
                Informacion = "La clase ha sido Creada exitosamente";
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

        public async Task<int> Update(int id, PostClaseDTO dto)
        {
            try
            {
                var marca = await _claseService.GetById(id);

                if (marca == null)
                {
                    Informacion = "La clase para Actualizar no existe en base de datos";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _claseService.Update(id, dto);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }
                Informacion = "La clase ha sido Actualizada exitosamente";
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
                var marca = await _claseService.GetById(id);

                if (marca == null)
                {
                    Informacion = "La clase que intenta eliminar no existe";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _claseService.Delete(id);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }

                Informacion = "La clase ha sido eliminado exitosamente";
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
