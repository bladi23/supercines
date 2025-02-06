using System.ComponentModel.DataAnnotations;


namespace supercines.Models
{
    public class personasModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }
        public int CantidadPeliculas { get; set; }
    }
}
