using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace supercines.Models
{
    public class repartosModel
    {
        [Key]
        public int Id { get; set; }
        // Relación con Película (Muchos a Uno)
        [ForeignKey("Pelicula")]
        public int PeliculaId { get; set; }
        public peliculasModel Pelicula { get; set; }
        // Relación con Persona (actor)
        [ForeignKey("Persona")]

        public int PersonaId { get; set; }
        public personasModel Persona { get; set; }

        [Required(ErrorMessage = "El personaje es requerido")]
        [Display(Name = "Personaje")]
        public string Personaje { get; set; }
    }
}
