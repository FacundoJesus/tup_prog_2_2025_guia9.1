using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parte2.Models;

namespace Parte1.Models
{
    public class Persona:IComparable,IExportable
    {
        public int DNI { get; set; }
        public string Nombre { get; set; }

        public Persona(int dni, string nombre) {
            this.DNI = dni;
            this.Nombre = nombre;
        }

        public int CompareTo(object obj)
        {
            Persona nuevaPersona = obj as Persona;
            if(nuevaPersona != null)
            {
                return this.DNI.CompareTo(nuevaPersona.DNI);
            }
            return -1;
        }

        public override string ToString() {

            return $"{this.Nombre} - ({this.DNI})";

        }

        public string Exportar()
        {
            throw new NotImplementedException();
        }

        public void Importar(string linea)
        {
            throw new NotImplementedException();
        }
    }
}
