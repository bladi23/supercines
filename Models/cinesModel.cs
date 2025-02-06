using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace supercines.Models
{
    public class cinesModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La direccion es requerida")]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El telefono es requerido")]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        public List<salasModel> Salas { get; set; } = new List<salasModel>();
    }
}
