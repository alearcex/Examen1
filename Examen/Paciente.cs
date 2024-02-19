using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
    public class Paciente
    {
        public string Nombre { get; set; }
        public int Cedula { get; set; }
        public int Telefono { get; set; }
        public string TipoSangre { get; set; }
        public string Direccion { get; set; }
        public DateOnly FechaNacimiento { get; set; } 

    }
    public class MedicamentoPaciente
    {
        public int CodigoMedicamento { get; set; }
        public int CodigoCedula { get; set; }
        public int Cantidad {  get; set; }
    }


}

