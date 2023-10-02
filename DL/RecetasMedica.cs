using System;
using System.Collections.Generic;

namespace DL;

public partial class RecetasMedica
{
    public int IdReceta { get; set; }

    public int? IdPaciente { get; set; }

    public DateTime? FechaConsulta { get; set; }

    public string Diagnostico { get; set; } = null!;

    public string NombreMedico { get; set; } = null!;

    public string NotasAdicionales { get; set; } = null!;

    public virtual Paciente? IdPacienteNavigation { get; set; }
    public string? NombrePaciente   { get; set; }
}
