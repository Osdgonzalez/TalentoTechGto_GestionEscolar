using System;
using System.Collections.Generic;

namespace GestionEscolar.Models;

public partial class Calificacione
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<AlumnosMateria> AlumnosMateria { get; } = new List<AlumnosMateria>();
}
