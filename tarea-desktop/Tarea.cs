using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarea_desktop
{
    public enum TareaPrioridad
    {
        Alta,
        Baja,
        Media
    }

    public class Tarea
    {
        public long id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public TareaPrioridad prioridad { get; set; }

        public Tarea(long id, string nombre, string descripcion, string prioridad)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.prioridad = parsePrioridad(prioridad);
        }

        public TareaPrioridad parsePrioridad(string prioridad)
        {
            switch (prioridad) {

                case "Alta":
                    return TareaPrioridad.Alta;
                case "Media":
                    return TareaPrioridad.Media;
                case "Baja":
                    return TareaPrioridad.Baja;
                default:
                    throw new Exception("Prioridad inexistente");
            }
        }

    }
}
