using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace supercines.Models
{
    public class salasModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Numero { get; set; }
        public int Capacidad { get; set; }

        public int CineId { get; set; }
        public cinesModel Cine { get; set; }

    }
}
