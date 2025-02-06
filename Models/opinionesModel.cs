using System;
using System.ComponentModel.DataAnnotations;

namespace supercines.Models
{
    public class opinionesModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El email es requerido")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "La edad es requerida")]
        [Display(Name = "Edad")]
        public int Edad { get; set; }
        [Required(ErrorMessage = "La fecha es requerida")]
        [Display(Name = "Fecha")]
        public DateOnly Fecha { get; set; }
        [Required(ErrorMessage = "La calificación es requerida")]
        [Display(Name = "Calificación")]
        public string Calificacion { get; set; } // Obra Maestra, Muy Buena, etc.
        [Required(ErrorMessage = "El comentario es requerido")]
        [Display(Name = "Comentario")]
        public string Comentario { get; set; }

        public int PeliculaId { get; set; }
        public peliculasModel Pelicula { get; set; }
    }
}
