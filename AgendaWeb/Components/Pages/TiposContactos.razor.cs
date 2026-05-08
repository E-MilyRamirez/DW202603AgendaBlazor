using AgendaWeb.Data.DTOS;
using AgendaWeb.Data.DTOS.Contactos;
using AgendaWeb.Services;
using Microsoft.AspNetCore.Components;

namespace AgendaWeb.Components.Pages
{
    public partial class TiposContactos
    {
        [Inject] TipoContactoServices Services { get; set; } = default!;

        private List<TipoContactoDto> ListaDeTiposContactos = new List<TipoContactoDto>();

        private bool CargandoDatos { get; set; } = false;

        protected async override Task OnInitializedAsync()
        {
            CargandoDatos = true;
            ListaDeTiposContactos = await Services.ObtenerTodosAsync();
            //await Task.Delay(3000); <- esto me ayuda a esperar 3 segundos
            CargandoDatos = false;
        }

        protected async Task EliminarTipoContacto(int id)
        {
            await Services.EliminarTipoContactoAsync(id);

            ListaDeTiposContactos = await Services.ObtenerTodosAsync();
        }
    }
}
