using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parte1.Models
{
    public class Cuenta:IComparable
    {
        public int Numero {  get; set; }


        private double saldo = 0;
        public double Saldo { 
            get {
                return saldo;
            }
            set { 
                saldo = value;
            }
        }

        public DateTime Fecha { get; set; }

        public Persona Titular { get; set; }

        public Cuenta(int numero, Persona titular)
        {
            this.Numero = numero;
            this.Titular = titular;
            this.Fecha = DateTime.Now;
        }

        public Cuenta(int numero, Persona titular, DateTime fecha, double saldo)
        {
            this.Numero = numero;
            this.Titular = titular;
            this.Fecha = fecha;
            this.Saldo = saldo;
        }

        public int CompareTo(object obj)
        {
            Cuenta nuevaCuenta = obj as Cuenta;
            if (nuevaCuenta != null)
            {
                return this.Numero.CompareTo(nuevaCuenta.Numero);
            }
            return -1;
        }

        public override string ToString()
        {
            return $"({this.Titular.DNI}) Nro. Cuenta: {this.Numero} Titular:{this.Titular.Nombre} - Saldo: ${this.Saldo:f2}";
        }


    }
}
