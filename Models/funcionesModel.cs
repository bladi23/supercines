using System;
using supercines.Models;



namespace supercines.Models
{
    public class funcionesModel
    {
        public int Id { get; set; }
        public int PeliculaId { get; set; }
        public peliculasModel Pelicula { get; set; }

        public int SalaId { get; set; }
        public salasModel Sala { get; set; }

        public string DiaSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
    }
}
