using System;
using System.Collections.Generic;

namespace GestionUsarios.Models
{
    public partial class TblAlumno
    {
        public string? AlmNombre { get; set; }
        public string? AlmApellido { get; set; }
        public int? AlmCreditos { get; set; }
        public int PkAlmIdAlumno { get; set; }
    }
}
