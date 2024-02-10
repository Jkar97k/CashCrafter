using CashCrafter.DTO;
using Service.Interfaces.Repository;

namespace CashCrafter.Service
{
    public class IngresoService : Mensaje, IIngresoService
    {
        private readonly IIngresoRepository _ingresoservice;

        public IngresoService(IIngresoRepository ingresoservice)
        {
            _ingresoservice = ingresoservice;
        }


        public async Task<List<IngresosDTO>> Get()
        {
            try
            {
                var dto = await _ingresoservice.Get();
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

        public async Task<IngresosDTO> GetById(int id)
        {
            try
            {
                var dto = await _ingresoservice.GetById(id);
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

        public async Task<int> Create(PostIngresosDTO dto)
        {
            try
            {


                var result = await _ingresoservice.Create(dto);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }
                Informacion = "El Ingreso ha sido Creada exitosamente";
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

        public async Task<int> Update(int id, PostIngresosDTO dto)
        {
            try
            {
                var marca = await _ingresoservice.GetById(id);

                if (marca == null)
                {
                    Informacion = "El Ingreso para Actualizar no existe en base de datos";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _ingresoservice.Update(id, dto);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }
                Informacion = "El Ingreso ha sido Actualizada exitosamente";
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
                var marca = await _ingresoservice.GetById(id);

                if (marca == null)
                {
                    Informacion = "El Ingreso que intenta eliminar no existe";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _ingresoservice.Delete(id);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }

                Informacion = "El Ingreso ha sido eliminado exitosamente";
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
