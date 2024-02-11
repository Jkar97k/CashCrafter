using CashCrafter.DTO;


namespace CashCrafter.Service
{
    public class CategoriaService : Mensaje, ICategoriaService
    {
        public readonly ICategoriaRepository _categoriaService;

        public CategoriaService(ICategoriaRepository categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public async Task<List<CategoriaDTO>> Get()
        {
            try
            {
                var dto = await _categoriaService.Get();
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

        public async Task<CategoriaDTO> GetById(int id)
        {
            try
            {
                var dto = await _categoriaService.GetById(id);
                if (dto == null)
                {
                    Informacion = "El Usuario que intenta buscar no existe";
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

        public async Task<int> Create(PostCategoriaDTO dto)
        {
            try
            {
                var marca = await _categoriaService.GetByName(dto.Nombre);
                if (marca != null)
                {
                    Informacion = "Este nombre ya existe en base de datos";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _categoriaService.Create(dto);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }
                Informacion = "La categoria ha sido Creada exitosamente";
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

        public async Task<int> Update(int id, PostCategoriaDTO dto)
        {
            try
            {
                var marca = await _categoriaService.GetById(id);

                if (marca == null)
                {
                    Informacion = "La categoria para Actualizar no existe en base de datos";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _categoriaService.Update(id, dto);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }
                Informacion = "La categoria ha sido Actualizada exitosamente";
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
                var marca = await _categoriaService.GetById(id);

                if (marca == null)
                {
                    Informacion = "La categoria que intenta eliminar no existe";
                    StatusCode = 400;
                    return 0;
                }

                var result = await _categoriaService.Delete(id);

                if (result == 0)
                {
                    Informacion = "Ha ocurrido un error en el servidor pongase en contacto con el administrador.";
                    StatusCode = 500;
                    return 0;
                }

                Informacion = "La categoria ha sido eliminado exitosamente";
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
