using CashCrafter.Api.DTO;
using CashCrafter.Api.Interfaces;

namespace CashCrafter.Api.Service
{
    public class TipoIngresoService : Mensaje, ITipoIngresoService
    {
        private readonly ITipoIngresoRepository _tipoIngresorepository;

        public TipoIngresoService(ITipoIngresoRepository tipoIngresorepository)
        {
            _tipoIngresorepository = tipoIngresorepository;
        }

        public async Task<List<TipoIngresoDTO>> Get()
        {
            try
            {
                var dto = await _tipoIngresorepository.Get();
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

        public async Task<TipoIngresoDTO> GetById(int id)
        {
            try
            {
                var dto = await _tipoIngresorepository.GetById(id);
                if (dto == null)
                {
                    Informacion = "El T.Ingreso que intenta buscar no existe";
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

        public async Task<int> Create(PostTipoIngresoDTO dto)
        {
            try
            {
                var marca = await _tipoIngresorepository.GetByName(dto.Tipo);
                if (marca != null)
                {
                    Informacion = "Este Tipo ya existe en base de datos";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _tipoIngresorepository.Create(dto);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }
                Informacion = "El T.Ingreso ha sido Creada exitosamente";
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

        public async Task<int> Update(int id, PostTipoIngresoDTO dto)
        {
            try
            {
                var marca = await _tipoIngresorepository.GetById(id);

                if (marca == null)
                {
                    Informacion = "El T.Ingreso para Actualizar no existe en base de datos";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _tipoIngresorepository.Update(id, dto);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }
                Informacion = "El T.Ingreso ha sido Actualizada exitosamente";
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
                var marca = await _tipoIngresorepository.GetById(id);

                if (marca == null)
                {
                    Informacion = "El T.Ingreso que intenta eliminar no existe";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _tipoIngresorepository.Delete(id);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }

                Informacion = "El T.Ingreso ha sido eliminado exitosamente";
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
