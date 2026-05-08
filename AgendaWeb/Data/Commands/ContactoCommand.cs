using AgendaWeb.Data.DTOS;
using AgendaWeb.Data.DTOS.Contactos;
using AgendaWeb.Data.Entities;
using Microsoft.Data.SqlClient;

namespace AgendaWeb.Data.Commands
{
    public class ContactoCommand
    {
        private readonly SQLServer _sqlServer;

        public ContactoCommand(SQLServer sqlServer)
        {
            _sqlServer = sqlServer;
        }

        public async Task<int> InsertarContactoAsync(Contacto contacto)
        {
            string query = "INSERT INTO Contactos" +
                " (Nombre, Telefono, Email, TipoContactoId) " +
                "VALUES " +
                "(@Nombre, @Telefono, @Email, @TipoContactoId)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Nombre", contacto.Nombre),
                new SqlParameter("@Telefono", contacto.Telefono),
                new SqlParameter("@Email", contacto.Email),
                new SqlParameter("@TipoContactoId", contacto.TipoContactoId)
            };
            return await _sqlServer.NonQueryAsync(query, parameters);
        }

        public async Task<int> EliminarContactoAsync(int id)
        {
            string query = "DELETE FROM Contactos WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", id)
            };
            return await _sqlServer.NonQueryAsync(query, parameters);
        }

        public async Task<int> ActualizarContactoAsync(int id, Contacto contacto)
        {
            string query = "UPDATE Contactos " +
                "SET" +
                " Nombre = @Nombre, " +
                "Telefono = @Telefono, " +
                "Email = @Email, " +
                "TipoContactoId = @TipoContactoId " +
                "WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@Nombre", contacto.Nombre),
                new SqlParameter("@Telefono", contacto.Telefono),
                new SqlParameter("@Email", contacto.Email),
                new SqlParameter("@TipoContactoId", contacto.TipoContactoId)
            };
            return await _sqlServer.NonQueryAsync(query, parameters);
        }

        public async Task<List<ContactoDto>> ObtenerTodosAsync()
        {
            //c es la tabla Contactos y tc es la tabla TiposContactos, se hace un LEFT JOIN para obtener la descripción del tipo de contacto
            string query = @"SELECT 
                    c.Id,
                    c.Nombre,
                    c.Telefono,
                    c.Email,
                    tc.Descripcion
                 FROM Contactos c
                 LEFT JOIN TiposContactos tc 
                    ON c.TipoContactoId = tc.Id
                 ORDER BY c.Nombre";
            var contactos = await _sqlServer.ReaderListAsync<ContactoDto>(query);
            return contactos;
        }

        public async Task<ContactoDto> ObtenerPorIdAsync(int id)
        {
            string query = @"SELECT Id, Nombre, Telefono, Email, TipoContactoId
                     FROM Contactos
                     WHERE Id = @Id";

            SqlParameter[] parameters =
            {
        new SqlParameter("@Id", id)
    };

            return await _sqlServer.ReaderAsync<ContactoDto>(query, parameters);
        }

        public async Task<List<TipoContactoDto>> ObtenerTiposContactosAsync()
        {
            string query = "SELECT Id, Descripcion FROM TiposContactos";

            return await _sqlServer.ReaderListAsync<TipoContactoDto>(query);
        }
    }
}
