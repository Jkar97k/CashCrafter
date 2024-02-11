using CashCrafter.DTO;

namespace CashCrafter.Service
{
    public class GastoService : Mensaje, IGastoService
    {
        private readonly IGastoRepository _gastoService;

        public GastoService(IGastoRepository gastoService)
        {
            _gastoService = gastoService;
        }

        public async Task<List<GastoDTO>> Get()
        {
            try
            {
                var dto = await _gastoService.Get();
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

        public async Task<GastoDTO> GetById(int id)
        {
            try
            {
                var dto = await _gastoService.GetById(id);
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

        public async Task<int> Create(PostGastoDTO dto)
        {
            try
            {
                var marca = await _gastoService.GetByName(dto.Item);
                if (marca != null)
                {
                    Informacion = "Este Gasto ya existe en base de datos";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _gastoService.Create(dto);

                if (result == 0)
                {
                    Informacion = "El Gasto un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }
                Informacion = "El Gasto ha sido Creada exitosamente";
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

        public async Task<int> Update(int id, PutGastoDTO dto)
        {
            try
            {
                var marca = await _gastoService.GetById(id);

                if (marca == null)
                {
                    Informacion = "El Gasto para Actualizar no existe en base de datos";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _gastoService.Update(id, dto);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }
                Informacion = "El Gasto ha sido Actualizada exitosamente";
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
                var marca = await _gastoService.GetById(id);

                if (marca == null)
                {
                    Informacion = "El Gasto que intenta eliminar no existe";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _gastoService.Delete(id);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }

                Informacion = "El Gasto ha sido eliminado exitosamente";
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
