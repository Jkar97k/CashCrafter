using CashCrafter.DTO;

namespace CashCrafter.Service
{
    public class AhorroService : Mensaje, IAhorroService
    {
        private readonly IAhorroRepository _ahorroService;

        public AhorroService(IAhorroRepository ahorroService)
        {
            _ahorroService = ahorroService;
        }

        public async Task<List<AhorroDTO>> Get()
        {
            try
            {
                var dto = await _ahorroService.Get();
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

        public async Task<AhorroDTO> GetById(int id)
        {
            try
            {
                var dto = await _ahorroService.GetById(id);
                if (dto == null)
                {
                    Informacion = "El Ingreso que intenta buscar no existe";
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

        public async Task<int> Create(PostAhorroDTO dto)
        {
            try
            {


                var result = await _ahorroService.Create(dto);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }
                Informacion = "Ahorro ha sido Creada exitosamente";
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

        public async Task<int> Update(int id, PostAhorroDTO dto)
        {
            try
            {
                var marca = await _ahorroService.GetById(id);

                if (marca == null)
                {
                    Informacion = "Ahorro para Actualizar no existe en base de datos";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _ahorroService.Update(id, dto);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }
                Informacion = "Ahorro ha sido Actualizada exitosamente";
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
                var marca = await _ahorroService.GetById(id);

                if (marca == null)
                {
                    Informacion = "Ahorro que intenta eliminar no existe";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _ahorroService.Delete(id);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }

                Informacion = "Ahorro ha sido eliminado exitosamente";
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
