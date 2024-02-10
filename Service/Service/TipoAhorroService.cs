using CashCrafter.DTO;


namespace CashCrafter.Service
{
    public class TipoAhorroService : Mensaje, ITipoAhorroService
    {
        private readonly ITipoAhorroRepository _tipoahorroservice;

        public TipoAhorroService(ITipoAhorroRepository tipoahorroservice)
        {
            _tipoahorroservice = tipoahorroservice;
        }


        public async Task<List<TipoAhorroDTO>> Get()
        {
            try
            {
                var dto = await _tipoahorroservice.Get();
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

        public async Task<TipoAhorroDTO> GetById(int id)
        {
            try
            {
                var dto = await _tipoahorroservice.GetById(id);
                if (dto == null)
                {
                    Informacion = "El T.Ahorro que intenta buscar no existe";
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

        public async Task<int> Create(PostTipoAhorroDTO dto)
        {
            try
            {
                var marca = await _tipoahorroservice.GetByName(dto.Nombre);
                if (marca != null)
                {
                    Informacion = "Este Tipo ya existe en base de datos";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _tipoahorroservice.Create(dto);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }
                Informacion = "El T.Ahorro ha sido Creada exitosamente";
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

        public async Task<int> Update(int id, PostTipoAhorroDTO dto)
        {
            try
            {
                var marca = await _tipoahorroservice.GetById(id);

                if (marca == null)
                {
                    Informacion = "El T.Ahorro para Actualizar no existe en base de datos";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _tipoahorroservice.Update(id, dto);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }
                Informacion = "El T.Ahorro ha sido Actualizada exitosamente";
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
                var marca = await _tipoahorroservice.GetById(id);

                if (marca == null)
                {
                    Informacion = "El T.Ahorro que intenta eliminar no existe";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _tipoahorroservice.Delete(id);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }

                Informacion = "El T.Ahorro ha sido eliminado exitosamente";
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
