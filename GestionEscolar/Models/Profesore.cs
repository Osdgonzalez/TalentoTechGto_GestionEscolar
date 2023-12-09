using System;
using System.Collections.Generic;

namespace GestionEscolar.Models;

public partial class Profesore
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Alumno> IdAlumnos { get; } = new List<Alumno>();

    public virtual ICollection<Materia> IdMateria { get; } = new List<Materia>();
}
