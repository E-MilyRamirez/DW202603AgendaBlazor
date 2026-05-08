using AgendaWeb.Data.Commands;
using AgendaWeb.Data.DTOS;
using AgendaWeb.Data.DTOS.Contactos;
using AgendaWeb.Data.Entities;

namespace AgendaWeb.Services
{
    public class TipoContactoServices
    {
        private readonly TipoContactoCommand _tipoContactoCommand;
        public TipoContactoServices(TipoContactoCommand tipoContactoCommand)
        {
            _tipoContactoCommand = tipoContactoCommand;
        }

        public async Task InsertarAsync(TipoContactoNuevoDto tipocontactoNuevoDto)
        {
            TipoContacto tipocontacto = new TipoContacto();
            tipocontacto.Descripcion = tipocontactoNuevoDto.Descripcion;

            int registrosAfectados = await _tipoContactoCommand.InsertarTipoContactoAsync(tipocontacto);

            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo insertar el tipo de contacto.");
            }
        }

        public async Task<int> EliminarTipoContactoAsync(int id)
        {
            return await _tipoContactoCommand.EliminarTipoContactoAsync(id);
        }

        public async Task<int> ActualizarTipoContactoAsync(int id, TipoContactoActualizarDto tipocontactoActualizarDto)
        {
            TipoContacto tipocontacto = new TipoContacto
            {
                Descripcion = tipocontactoActualizarDto.Descripcion
            };
            return await _tipoContactoCommand.ActualizarTipoContactoAsync(id, tipocontacto);
        }

        public async Task<List<TipoContactoDto>> ObtenerTodosAsync()
        {
            return await _tipoContactoCommand.ObtenerTodosAsync();
        }

        public async Task<List<TipoContactoDto>> ObtenerTiposContactosAsync()
        {
            return await _tipoContactoCommand.ObtenerTiposContactosAsync();
        }
    }
}
