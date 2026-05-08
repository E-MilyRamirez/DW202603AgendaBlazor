using AgendaWeb.Data.DTOS;
using AgendaWeb.Data.Entities;
using Microsoft.Data.SqlClient;

namespace AgendaWeb.Data.Commands
{
    public class TipoContactoCommand
    {
        private readonly SQLServer _sqlServer;

        public TipoContactoCommand(SQLServer sqlServer)
        {
            _sqlServer = sqlServer;
        }

        public async Task<int> InsertarTipoContactoAsync(TipoContacto tipocontacto)
        {
            string query = "INSERT INTO TiposContactos" +
                " (Descripcion) " +
                "VALUES " +
                "(@Descripcion)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Descripcion", tipocontacto.Descripcion)
            };
            return await _sqlServer.NonQueryAsync(query, parameters);
        }

        public async Task<int> EliminarTipoContactoAsync(int id)
        {
            string query = "DELETE FROM TiposContactos WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", id)
            };
            return await _sqlServer.NonQueryAsync(query, parameters);
        }

        public async Task<int> ActualizarTipoContactoAsync(int id, TipoContacto tipocontacto)
        {
            string query = "UPDATE TiposContactos " +
                "SET" +
                " Descripcion = @Descripcion " +
                "WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@Descripcion", tipocontacto.Descripcion)
            };
            return await _sqlServer.NonQueryAsync(query, parameters);
        }

        public async Task<List<TipoContactoDto>> ObtenerTodosAsync() 
        {
            string query = "SELECT Id, Descripcion FROM TiposContactos ORDER BY Descripcion";
          
            return await _sqlServer.ReaderListAsync<TipoContactoDto>(query);
        }

        public async Task<List<TipoContactoDto>> ObtenerTiposContactosAsync()
        {
            string query = "SELECT Id, Descripcion FROM TiposContactos";

            return await _sqlServer.ReaderListAsync<TipoContactoDto>(query);
        }
    }
}
