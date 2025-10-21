using Parte1.Models;

namespace Parte1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        Banco banco = new Banco();
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

        }
    }
}
