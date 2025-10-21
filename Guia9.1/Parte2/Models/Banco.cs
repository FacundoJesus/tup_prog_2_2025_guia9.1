using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parte1.Models
{
    [Serializable]
    public class Banco
    {

        public int CantidadClientes {  
            get 
            {
                return listaClientes.Count;
            }
            set {}
        }

        public int CantidadCuentas {
            get
            {
                return listaCuentas.Count;
            }
            set {}
        }

        #region Indexador
        public Cuenta this[int idx]
        {
            get
            {
                if(idx >=0 && idx < CantidadCuentas)
                {
                    return listaCuentas[idx];
                }
                return null;
            }
        }
        #endregion

        public List<Cuenta> Cuentas
        {
            get { return listaCuentas; }
        }

        List<Persona> listaClientes = new List<Persona>();
        List<Cuenta> listaCuentas = new List<Cuenta>();

        public Cuenta AgregarCuenta(int numeroCuenta, int dni, string nombre)
        {
            Cuenta siCuentaExiste = VerCuentaPorNumero(numeroCuenta);

            //Buscar si la cuenta ya existe
            if (siCuentaExiste == null)
            {
                // Buscar si la persona ya está registrada
                Persona titular = VerClientePorDNI(dni);
                if (titular == null)
                {
                    titular = new Persona(dni, nombre);
                    listaClientes.Add(titular);
                }

                Cuenta nuevaCuenta = new Cuenta(numeroCuenta, titular);
                listaCuentas.Add(nuevaCuenta);
                CantidadCuentas++;
                CantidadClientes++;

                return nuevaCuenta;

            }
            return null;
        }

        public Cuenta VerCuentaPorNumero(int numeroCuenta)
        {
            Cuenta cuentaBuscada = new (numeroCuenta,null);
            
            listaCuentas.Sort();
            int idx = listaCuentas.BinarySearch(cuentaBuscada);
            if (idx > -1)
            {
                return listaCuentas[idx];
            }
            return null;
        }

        public Persona VerClientePorDNI(int dni)
        {
            Persona clienteBuscado = new Persona(dni,null); 
            listaClientes.Sort();
            int idx = listaClientes.BinarySearch(clienteBuscado);
            if (idx > -1)
            {
                return listaClientes[idx];
            }
            return null;
        }

        public bool RestaurarCuenta(int numero, double saldo, DateTime fecha, Persona cliente)
        {
            if (VerCuentaPorNumero(numero) == null)
            {
                Persona titular = VerClientePorDNI(cliente.DNI);
                if (titular == null)
                {
                    titular = cliente;
                    listaClientes.Add(titular);
                }

                Cuenta cuentaRestaurada = new Cuenta(numero, titular);

                cuentaRestaurada.Saldo = saldo;
                cuentaRestaurada.Fecha = fecha;
                

                listaCuentas.Add(cuentaRestaurada);
                return true;
            }
            return false;
        }
    }
}
