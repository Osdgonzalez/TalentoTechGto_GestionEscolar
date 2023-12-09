using System;
using System.Collections.Generic;

namespace GestionEscolar.Models;

public partial class Materia
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<AlumnosMateria> AlumnosMateria { get; } = new List<AlumnosMateria>();

    public virtual ICollection<Profesore> IdProfesors { get; } = new List<Profesore>();
}
