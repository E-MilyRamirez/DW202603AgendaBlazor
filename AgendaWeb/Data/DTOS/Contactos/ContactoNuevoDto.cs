using System.ComponentModel.DataAnnotations;

namespace AgendaWeb.Data.DTOS.Contactos
{
    public class ContactoNuevoDto
    {
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Nombre { get; set; }
        
       
        public string Telefono { get; set; }

        public int TipoContactoId { get; set; }

        [Required(ErrorMessage = "El campo Email es requerido")]
        public string Email { get; set; }
    }
}
