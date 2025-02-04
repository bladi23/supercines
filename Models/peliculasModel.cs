using System.ComponentModel.DataAnnotations;

namespace supercines.Models
{
    public class peliculasModel
    {
        [Key]
        public int IdPelicula { get; set;}
       
        [Required (ErrorMessage = "El titulo de distribucion requerido")]
        [Display(Name = "Titulo de distribucion")]
        public string TituloDistribucion { get; set; }

        [Required(ErrorMessage = "El titulo original es requerido")]
        [Display(Name = "Titulo Original")]
        public string TituloOriginal { get; set; }
        [Required(ErrorMessage = "El genero es requerido")]
        [Display(Name = "Genero")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "El idioma original es requerido")]
        [Display(Name = "Idioma Orginal")]
        public string IdiomaOriginal { get; set; }
        [Required(ErrorMessage = "Los subtitulos son requerido")]
        [Display(Name = "Subtitulada")]
        public bool Subtitulada { get; set; }
        [Required(ErrorMessage = "El pais de origen es requerido")]
        [Display(Name = "Nombre del Pais")]
        public string PaisOrigen { get; set; }
        [Required(ErrorMessage = "El año de produccion es requerido")]
        [Display(Name = "Año de prpduccion")]
        public int AñoProduccion { get; set; }
        [Required(ErrorMessage = "La URL del sitio web es requerida")]
        [Display(Name = "URL sitio web")]
        public string UrlSitioWeb { get; set; }
        public TimeSpan Duracion { get; set; }
        public string Clasificacion { get; set; }
        public DateOnly FechaEstreno { get; set; }
        public string Resumen { get; set; }
    }
}
