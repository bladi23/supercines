
using System.ComponentModel.DataAnnotations;


namespace supercines.Models
{
    public class promocionesModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El descuento es requerido")]
        [Display(Name = "Descuento")]
        public double Descuento { get; set; }

        public int FuncionId { get; set; }
        public funcionesModel Funcion { get; set; }
    }
}
