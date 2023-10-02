using System;
using System.Collections.Generic;

namespace DL;

public partial class Paciente
{
    public int IdPaciente { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string? ApellidoMaterno { get; set; }

    public virtual ICollection<RecetasMedica> RecetasMedicas { get; set; } = new List<RecetasMedica>();
}
