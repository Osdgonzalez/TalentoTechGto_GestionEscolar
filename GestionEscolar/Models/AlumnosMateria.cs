using System;
using System.Collections.Generic;

namespace GestionEscolar.Models;

public partial class AlumnosMateria
{
    public int IdAlumno { get; set; }

    public int IdMateria { get; set; }

    public int IdCalificacion { get; set; }

    public virtual Alumno IdAlumnoNavigation { get; set; } = null!;

    public virtual Calificacione IdCalificacionNavigation { get; set; } = null!;

    public virtual Materia IdMateriaNavigation { get; set; } = null!;
}
