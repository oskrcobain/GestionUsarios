using System;
using System.Collections.Generic;

namespace GestionUsarios.Models
{
    public partial class TblMaterium
    {
        public string? MtrNombre { get; set; }
        public string? MtrModulo { get; set; }
        public string? MtrCurso { get; set; }
        public int? FkPgmIdPrograma { get; set; }
        public int PkMtrIdMateria { get; set; }

        public virtual TblPrograma? FkPgmIdProgramaNavigation { get; set; }
    }
}
