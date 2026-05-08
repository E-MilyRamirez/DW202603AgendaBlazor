namespace AgendaWeb.Data.Entities
{
    public class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public int TipoContactoId { get; set; }
    }
}
