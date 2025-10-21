using Parte1.Models;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Parte1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Cuenta cuenta1 = banco.AgregarCuenta(1812, 40158729, "Citera, Facundo");
            cuenta1.Saldo = 20000;
            Cuenta cuenta2 = banco.AgregarCuenta(1231, 30232523, "Claucich, Román");
            cuenta2.Saldo = 25623;
            Cuenta cuenta3 = banco.AgregarCuenta(1112, 41253822, "Stell,María");
            cuenta3.Saldo = 2536567;
            Cuenta cuenta4 = banco.AgregarCuenta(1088, 39582124, "DeLaGranja, Ana");
            cuenta4.Saldo = 22357.58;
            Cuenta cuenta5 = banco.AgregarCuenta(1024, 42123627, "Gonzales, Fernando");
            cuenta5.Saldo = 122544.56;

        }

        Banco banco = new Banco();

        private void btnVerCuentas_Click(object sender, EventArgs e)
        {
            lsbResultado.Items.Clear();
            foreach(Cuenta c in  banco.Cuentas)
            {
                lsbResultado.Items.Add(c);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream fs = null;
            string path = "ejercicio1.dat"; //Archivo binario interno del programa
            if (File.Exists(path))
            {
                try
                {

                    fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
                    #pragma warning disable SYSLIB0011
                    BinaryFormatter bf = new BinaryFormatter();
                    banco = bf.Deserialize(fs) as Banco;
                    #pragma warning restore SYSLIB0011
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR al cargar Datos en Formato Binario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (fs != null) fs.Close();
                }

            }
        }

        private void btnImportarCuentas_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(csv)|*.csv";
            ofd.Title = "Importación  de fichero Clientes";

            if (ofd.ShowDialog() == DialogResult.OK)
            {

                string path = ofd.FileName;
                FileStream fs = null;
                StreamReader sr = null;
                try
                {
                    fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    sr = new StreamReader(fs);

                    sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        string linea = sr.ReadLine();
                        string[] splitResult = linea.Split(';');

                        int dni = Convert.ToInt32(splitResult[0]);
                        string nombre = splitResult[1];

                        int numeroCuenta = Convert.ToInt32(splitResult[2]);
                        double saldo = Convert.ToDouble(splitResult[3]);

                        Persona titular = new Persona(dni, nombre);
                        Cuenta cuentaExistente = banco.VerCuentaPorNumero(numeroCuenta);

                        if (cuentaExistente != null)
                        {
                            cuentaExistente.Saldo += saldo;
                        }
                        Cuenta nuevaCuenta = banco.AgregarCuenta(numeroCuenta, dni, nombre);
                        nuevaCuenta.Saldo = saldo;
                    }

                    foreach (Cuenta cuenta in banco.Cuentas)
                    {
                        lsbResultado.Items.Add(cuenta);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sr != null) sr.Close();
                    if (fs != null) fs.Close();
                }
            }
        }

        private void btnExportarCuentas_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Exportación de cuentas que superan los 10.000";
            sfd.Filter = "(csv)|*.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = null;
                StreamWriter sw = null;
                string path = sfd.FileName;
                try
                {
                    fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write);
                    sw = new StreamWriter(fs);
                    sw.WriteLine("DNI; nombre; número de cuenta; saldo");
                    foreach (Cuenta c in banco.Cuentas)
                    {
                        if (c.Saldo > 7000)
                        {
                            sw.WriteLine($"{c.Titular.DNI};{c.Titular.Nombre};{c.Numero};{c.Saldo}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sw != null) sw.Close();
                    if (fs != null) fs.Close();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileStream fs = null;
            string path = "ejercicio.dat"; //Mismo archivo binario interno.
            try
            {
                fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                #pragma warning disable SYSLIB0011
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, banco);
                #pragma warning restore SYSLIB0011
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR al guardar Datos en Formato binario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }


    }
}
