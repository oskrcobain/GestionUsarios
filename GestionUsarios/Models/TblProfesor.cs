using System;
using System.Collections.Generic;

namespace GestionUsarios.Models
{
    public partial class TblProfesor
    {
        public string? PfsNombres { get; set; }
        public string? PfsApellidos { get; set; }
        public string? PfsEspecialidad { get; set; }
        public string? PfsCargo { get; set; }
        public int? FkPgmIdPrograma { get; set; }
        public int PkPfsIdProfesor { get; set; }

        public virtual TblPrograma? FkPgmIdProgramaNavigation { get; set; }
    }
}
