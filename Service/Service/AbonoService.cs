using CashCrafter.DTO;
using Service.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashCrafter.Service
{
    public class AbonoService : Mensaje, IAbonoService
    {
        private readonly IAbonoRepository _abonoservice;

        public AbonoService(IAbonoRepository abonoservice)
        {
            _abonoservice = abonoservice;
        }


        public async Task<List<AbonoDTO>> Get()
        {
            try
            {
                var dto = await _abonoservice.Get();
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

        public async Task<AbonoDTO> GetById(int id)
        {
            try
            {
                var dto = await _abonoservice.GetById(id);
                if (dto == null)
                {
                    Informacion = "El Abono que intenta buscar no existe";
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

        public async Task<int> Create(PostAbonoDTO dto)
        {
            try
            {


                var result = await _abonoservice.Create(dto);

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

        public async Task<int> Update(int id, PutAbonoDTO dto)
        {
            try
            {
                var marca = await _abonoservice.GetById(id);

                if (marca == null)
                {
                    Informacion = "El Abono para Actualizar no existe en base de datos";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _abonoservice.Update(id, dto);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }
                Informacion = "El Abono ha sido Actualizada exitosamente";
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
                var marca = await _abonoservice.GetById(id);

                if (marca == null)
                {
                    Informacion = "El Abono que intenta eliminar no existe";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _abonoservice.Delete(id);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }

                Informacion = "El Abono ha sido eliminado exitosamente";
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
