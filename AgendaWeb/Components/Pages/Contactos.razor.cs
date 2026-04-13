using AgendaWeb.Data.DTOS.Contactos;
using AgendaWeb.Services;
using Microsoft.AspNetCore.Components;

namespace AgendaWeb.Components.Pages
{
    public partial class Contactos
    {
        [Inject] ContactoServices Services { get; set; } = default!;

        private List<ContactoDto> ListaDeContactos = new List<ContactoDto>();

        private bool CargandoDatos {  get; set; } = false;

        protected async override Task OnInitializedAsync()
        {
            CargandoDatos = true;
            ListaDeContactos = await Services.ObtenerTodosAsync();
            //await Task.Delay(3000); <- esto me ayuda a esperar 3 segundos
            CargandoDatos = false;
        }
    }
}
