using System;
using System.Collections.Generic;

namespace GestionUsarios.Models
{
    public partial class TblMateriaHasAlumno
    {
        public int? FkMtrIdMateria { get; set; }
        public int? FkAlmIdAlumno { get; set; }
        public int PkAlmHasMtrIdAlumnoHasMateria { get; set; }

        public virtual TblAlumno? FkAlmIdAlumnoNavigation { get; set; }
        public virtual TblMaterium? FkMtrIdMateriaNavigation { get; set; }
    }
}
