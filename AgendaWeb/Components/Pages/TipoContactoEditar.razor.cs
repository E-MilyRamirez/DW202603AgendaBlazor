using AgendaWeb.Data.DTOS;
using AgendaWeb.Data.DTOS.Contactos;
using AgendaWeb.Services;
using Microsoft.AspNetCore.Components;

namespace AgendaWeb.Components.Pages
{
    public partial class TipoContactoEditar
    {
        protected TipoContactoActualizarDto TipoContacto { get; set; } = new();

        protected bool MensajeExito { get; set; } = false;

        protected List<TipoContactoDto> TiposContactos { get; set; } = new();

        [Inject] protected NavigationManager Navigation { get; set; }
        [Inject] protected TipoContactoServices TipoContactoServices { get; set; }

        protected override async Task OnInitializedAsync()
        {
            TiposContactos = await TipoContactoServices.ObtenerTiposContactosAsync();
        }

        protected async Task GuardarTipoContacto()
        {
            await TipoContactoServices.ActualizarTipoContactoAsync(Id, TipoContacto);
            Navigation.NavigateTo("/tiposcontactos");

        }
        protected void Cancelar()
        {
            Navigation.NavigateTo("/tiposcontactos");
        }
        [Parameter] public int Id { get; set; }
    }
}
