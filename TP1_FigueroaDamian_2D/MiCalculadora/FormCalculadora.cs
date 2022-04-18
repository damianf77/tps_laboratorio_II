using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento del boton btnLimpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar(); 
        }

        /// <summary>
        /// Evento del boton btnCerrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento del boton btnConvertirABinario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if(this.lblResultado.Text != String.Empty)
            {
                this.lblResultado.Text = Entidades.Operando.DecimalBinario(this.lblResultado.Text);
                btnConvertirABinario.Enabled = false;
                btnConvertirADecimal.Enabled = true;
            }

        }

        /// <summary>
        /// Evento del boton btnConvertirADecimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if(this.lblResultado.Text != String.Empty)
            {
              this.lblResultado.Text = Entidades.Operando.BinarioDecimal(this.lblResultado.Text);
               btnConvertirABinario.Enabled = true;
               btnConvertirADecimal.Enabled = false;
            }
        }

        /// <summary>
        /// Recibe los dos números y el operador para luego llamar al método Operar de Calculadora y 
        /// retorna el resultado al método de evento del botón btnOperar que reflejará el resultado en el Label txtResultado. 
        /// </summary>
        /// <param name="numero1">numero a operar</param>
        /// <param name="numero2">numero a operar</param>
        /// <param name="operador">operador que determinara que operacion se realiza</param>
        /// <returns>retorna el resultado en formato double de la operacion</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando num1 = new Operando(numero1);
            Operando num2 = new Operando(numero2);
            double resultado;

            resultado = Calculadora.Operar(num1, num2, operador);

            return resultado;
        }

        /// <summary>
        /// Evento del boton btnOperar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double respuesta;
            string operadorAux="";
            if(this.cmbOperador.SelectedItem == null)
            {
                operadorAux = "+";
            }
            else
            {
                operadorAux = this.cmbOperador.SelectedItem.ToString();
            }
            respuesta = Operar(this.txtNumero1.Text, this.txtNumero2.Text, operadorAux);
            this.lblResultado.Text = Convert.ToString(respuesta);
            this.btnConvertirADecimal.Enabled = false;
            this.btnConvertirABinario.Enabled = true;

        }

        /// <summary>
        /// Deja todos los campos vacios y reestablecidos
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = String.Empty;
            this.txtNumero2.Text = String.Empty;
            this.cmbOperador.SelectedIndex = -1;
            this.lblResultado.Text = String.Empty;
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }


    }
}
