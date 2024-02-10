using CashCrafter.DTO;
using CashCrafter.Service;
using CashCrafter.Api.Repository;

namespace CashCrafter.Service
{
    public class TipoPagoService : Mensaje, ITipoPagoService
    {
        private readonly ITipoPagoRepository _tipoPagoRepository;

        public TipoPagoService(ITipoPagoRepository tipoPagoRepository)
        {
            _tipoPagoRepository = tipoPagoRepository;
        }

        public async Task<List<TipoPagoDTO>> Get()
        {
            try
            {
                var dto = await _tipoPagoRepository.Get();
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

        public async Task<TipoPagoDTO> GetById(int id)
        {
            try
            {
                var dto = await _tipoPagoRepository.GetById(id);
                if (dto == null)
                {
                    Informacion = "El Tipo de pago que intenta buscar no existe";
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

        public async Task<int> Create(PostTipoPagoDTO dto)
        {
            try
            {
                var marca = await _tipoPagoRepository.GetByName(dto.Nombre);
                if (marca != null)
                {
                    Informacion = "Este nombre ya existe en base de datos";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _tipoPagoRepository.Create(dto);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }
                Informacion = "El Tipo de pago ha sido Creada exitosamente";
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

        public async Task<int> Update(int id, PostTipoPagoDTO dto)
        {
            try
            {
                var marca = await _tipoPagoRepository.GetById(id);

                if (marca == null)
                {
                    Informacion = "El Tipo de pago para Actualizar no existe en base de datos";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _tipoPagoRepository.Update(id, dto);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }
                Informacion = "El Tipo de pago ha sido Actualizada exitosamente";
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
                var marca = await _tipoPagoRepository.GetById(id);

                if (marca == null)
                {
                    Informacion = "El Tipo de pago que intenta eliminar no existe";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _tipoPagoRepository.Delete(id);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }

                Informacion = "El Tipo de pago ha sido eliminado exitosamente";
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
