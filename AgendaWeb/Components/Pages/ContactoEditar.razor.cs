using AgendaWeb.Data.DTOS;
using AgendaWeb.Data.DTOS.Contactos;
using AgendaWeb.Services;
using Microsoft.AspNetCore.Components;

namespace AgendaWeb.Components.Pages
{
    public partial class ContactoEditar
    {
        protected ContactoActualizarDto Contacto { get; set; } = new();

        protected bool MensajeExito { get; set; } = false;

        protected List<TipoContactoDto> TiposContactos { get; set; } = new();

        [Inject] protected NavigationManager Navigation { get; set; }
        [Inject] protected ContactoServices ContactoServices { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Contacto = await ContactoServices.ObtenerPorIdAsync(Id);
            TiposContactos = await ContactoServices.ObtenerTiposContactosAsync();
        }

        protected async Task GuardarContacto()
        {
            await ContactoServices.ActualizarContactoAsync(Id, Contacto);
            Navigation.NavigateTo("/contactos");

        }
        protected void Cancelar()
        {
            Navigation.NavigateTo("/contactos");
        }
    [Parameter] public int Id { get; set; }
    }
}
