using System.ComponentModel.DataAnnotations;

namespace AgendaWeb.Data.DTOS.Contactos
{
    public class TipoContactoNuevoDto
    {
        [Required(ErrorMessage = "El campo Descripcion es requerido")]
        public string Descripcion { get; set; }
    }
}
