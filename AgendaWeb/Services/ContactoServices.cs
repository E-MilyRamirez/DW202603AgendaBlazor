using AgendaWeb.Data.Commands;
using AgendaWeb.Data.DTOS;
using AgendaWeb.Data.DTOS.Contactos;
using AgendaWeb.Data.Entities;

namespace AgendaWeb.Services
{
    public class ContactoServices
    {
        private readonly ContactoCommand _contactoCommand;

        public ContactoServices(ContactoCommand contactoCommand)
        {
            _contactoCommand = contactoCommand;
        }

        public async Task InsertarAsync(ContactoNuevoDto contactoNuevoDto)
        {
            Contacto contacto = new Contacto();
            contacto.Nombre = contactoNuevoDto.Nombre;
            contacto.Telefono = contactoNuevoDto.Telefono;
            contacto.Email = contactoNuevoDto.Email;
            contacto.TipoContactoId = contactoNuevoDto.TipoContactoId;

            int registrosAfectados = await _contactoCommand.InsertarContactoAsync(contacto);

            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo insertar el contacto.");
            }
        }
        public async Task<int> EliminarContactoAsync(int id)
        {
            return await _contactoCommand.EliminarContactoAsync(id);
        }

        public async Task<int> ActualizarContactoAsync(int id, ContactoActualizarDto contactoActualizarDto)
        {
            Contacto contacto = new Contacto
            {
                Nombre = contactoActualizarDto.Nombre,
                Telefono = contactoActualizarDto.Telefono,
                Email = contactoActualizarDto.Email,
                TipoContactoId = contactoActualizarDto.TipoContactoId
            };
            return await _contactoCommand.ActualizarContactoAsync(id, contacto);
        }

        public async Task<List<ContactoDto>> ObtenerTodosAsync()
        {
            List<ContactoDto> contactosDto = await _contactoCommand.ObtenerTodosAsync();

            //foreach (var c in contactos)
            //{
            //    ContactoDto contactoDto = new ContactoDto
            //    {
            //        Id = c.Id,
            //        Nombre = c.Nombre,
            //        Telefono = c.Telefono,
            //        Email = c.Email
            //    };
            //    contactosDto.Add(contactoDto);
            //}
            // Usando LINQ para proyectar cada Contacto a ContactoDto
            //List<ContactoDto> contactosDto = contactos.Select(
            //    c => new ContactoDto //c conctacto y contactoDto es el nuevo objeto que se va a crear
            //    {
            //        Id = c.Id,
            //        Nombre = c.Nombre,
            //        Telefono = c.Telefono,
            //        Email = c.Email
            //    }).ToList();

            return contactosDto;
        }

        public async Task<ContactoActualizarDto> ObtenerPorIdAsync(int id)
        {
            ContactoDto contactoDto = await _contactoCommand.ObtenerPorIdAsync(id);

            return new ContactoActualizarDto
            {
                Nombre = contactoDto.Nombre,
                Telefono = contactoDto.Telefono,
                Email = contactoDto.Email,
                TipoContactoId = contactoDto.TipoContactoId
            };
        }

        public async Task<List<TipoContactoDto>> ObtenerTiposContactosAsync()
        {
            return await _contactoCommand.ObtenerTiposContactosAsync();
        }
    }
}
