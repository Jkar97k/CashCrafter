using AutoMapper;
using CashCrafter.Api.Context;
using CashCrafter.DTO;
using CashCrafter.Service;
using CashCrafter.Api.Model;
using CashCrafter.Api.Repository;
using Microsoft.EntityFrameworkCore;

namespace CashCrafter.Service
{
    public class GastosRService : Mensaje, IGastosRService
    {
        private readonly IGastosrRepository _gastosrService;

        public GastosRService(IGastosrRepository gastosrRepository)
        {
            _gastosrService = gastosrRepository;
        }

        public async Task<List<GastoRDTO>> Get()
        {
            try
            {
                var dto = await _gastosrService.Get();
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

        public async Task<GastoRDTO> GetById(int id)
        {
            try
            {
                var dto = await _gastosrService.GetById(id);
                if (dto == null)
                {
                    Informacion = "El GR que intenta buscar no existe";
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

        public async Task<int> Create(PostGastosRDTO dto)
        {
            try
            {
                var marca = await _gastosrService.GetByName(dto.Item);
                if (marca != null)
                {
                    Informacion = "Este Item ya existe en base de datos";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _gastosrService.Create(dto);

                if (result == 0)
                {
                    Informacion = "El GR un error en el servidor pongase en contacto con el administrador.";
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

        public async Task<int> Update(int id, PutGastosRDTO dto)
        {
            try
            {
                var marca = await _gastosrService.GetById(id);

                if (marca == null)
                {
                    Informacion = "El GR para Actualizar no existe en base de datos";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _gastosrService.Update(id, dto);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }
                Informacion = "El GR ha sido Actualizada exitosamente";
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
                var marca = await _gastosrService.GetById(id);

                if (marca == null)
                {
                    Informacion = "El GR que intenta eliminar no existe";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _gastosrService.Delete(id);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }

                Informacion = "El GR ha sido eliminado exitosamente";
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
