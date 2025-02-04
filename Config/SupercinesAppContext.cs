using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace supercines.Config
{
    public class SupercinesAppContext:DbContext
    {
        public SupercinesAppContext(DbContextOptions contexto):base(contexto)
        {
        }
        /*peliculas
         * personas
         * repartos
         * cines
         * salas
         * funciones
         * promociones
         * opiniones
         * */
    }
}
