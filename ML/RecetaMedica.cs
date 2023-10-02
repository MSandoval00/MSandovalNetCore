using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class RecetaMedica
    {
        public int IdReceta { get; set; }
        public ML.Paciente Paciente { get; set; }
        public string FechaConsulta { get; set; }
        public string  Diagnostico { get; set; }
        public string NombreMedico { get; set; }
        public string NotasAdicionales { get; set; }
        public List<object> RecetasMedicas { get; set; }
    }
}
