using System;
using System.Collections.Generic;

namespace GestionUsarios.Models
{
    public partial class TblPrograma
    {
        public TblPrograma()
        {
            TblMateria = new HashSet<TblMaterium>();
            TblProfesors = new HashSet<TblProfesor>();
        }

        public string? PgmNombre { get; set; }
        public int? PgmDuracion { get; set; }
        public int? PgmCosto { get; set; }
        public string? PgmAula { get; set; }
        public int PkPgmIdPrograma { get; set; }

        public virtual ICollection<TblMaterium> TblMateria { get; set; }
        public virtual ICollection<TblProfesor> TblProfesors { get; set; }
    }
}
