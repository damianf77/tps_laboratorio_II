using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        double numero;

        /// <summary>
        /// Propiedad para asignar un valor al atributo numero
        /// luego de haberlo validado con el metodo ValidarNumero
        /// </summary>
        public string SetNumero
        {
            set 
            { 
                this.numero = ValidarNumero(value); 
            }
        }

        /// <summary>
        /// Constructor por defecto, este asigna 0 al atributo numero
        /// de la clase Numero
        /// </summary>
        public Operando()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor para asignar un double al atributo numero
        /// de la clase Numero
        /// </summary>
        /// <param name="numero">numero en formato double a asignar</param>
        public Operando(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor para asignar un numero que llega por parametro
        /// en formato string con la propiedad setNumero
        /// </summary>
        /// <param name="strNumero">numero a asignar en formato string</param>
        public Operando(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Comprueba que  que el valor recibido sea numérico, y lo retornará 
        /// en formato double
        /// </summary>
        /// <param name="strNumero">string a validar</param>
        /// <returns></returns>
        private double ValidarNumero(string strNumero)
        {
            double exito;
            if (!double.TryParse(strNumero, out exito))
            {
                exito = 0;
            }
            return exito;
        }

        /// <summary>
        /// Sobrecarga del operador +
        /// </summary>
        /// <param name="n1">objeto de la clase Numero</param>
        /// <param name="n2">objeto de la clase Numero</param>
        /// <returns>retorna la suma de los numeros en fomato double</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            double retorno = 0;

            retorno = n1.numero + n2.numero;

            return retorno;

        }

        /// <summary>
        /// Sobrecarga del operador -
        /// </summary>
        /// <param name="n1">objeto de la clase Numero</param>
        /// <param name="n2">objeto de la clase Numero</param>
        /// <returns>retorna la resta de los numeros en fomato double</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            double retorno = 0;

            retorno = n1.numero - n2.numero;

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador *
        /// </summary>
        /// <param name="n1">objeto de la clase Numero</param>
        /// <param name="n2">objeto de la clase Numero</param>
        /// <returns>retorna la multiplicacion de los numeros en fomato double</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            double retorno = 0;

            retorno = n1.numero * n2.numero;

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador /
        /// </summary>
        /// <param name="n1">objeto de la clase Numero</param>
        /// <param name="n2">objeto de la clase Numero</param>
        /// <returns>retorna la division de los numeros en fomato double</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            double retorno = 0;
            if (n2.numero == 0)
            {
                retorno = double.MinValue;
            }
            else
            {
                retorno = n1.numero / n2.numero;
            }

            return retorno;
        }

        /// <summary>
        /// Verifica que la cadena que llega por parametro este compuesta
        /// por 1 y 0 unicamente
        /// </summary>
        /// <param name="binario">cadena a verificar</param>
        /// <returns>retorna true si es binaria la cadena, false si no lo es</returns>
        private static bool EsBinario(string binario)
        {
            bool exito = true;

            char[] cadenaBinaria = binario.ToCharArray();

            for (int i = 0; i < cadenaBinaria.Length; i++)
            {
                if (cadenaBinaria[i] != '0' && cadenaBinaria[i] != '1')
                {
                    exito = false;
                    break;
                }
            }
            return exito;
        }

        /// <summary>
        /// Convertira la cadena que llega por parametro a decimal
        /// con previa verificacion
        /// </summary>
        /// <param name="binario">cadena binaria a convertir</param>
        /// <returns>devuelve la cadena en decimal, caso contrario devuelve valor invalido</returns>
        public static string BinarioDecimal(string binario)
        {
            string strResultado = "Valor invalido";

            if (EsBinario(binario))
            {
                char[] charBinario = binario.ToCharArray();
                Array.Reverse(charBinario);

                double acumuladorResultado = 0;

                for (int i = 0; i < charBinario.Length; i++)
                {
                    if (charBinario[i] == '1')
                    {
                        if (i == 0)
                        {
                            acumuladorResultado += 1;

                        }
                        else
                        {
                            acumuladorResultado += (int)Math.Pow(2, i);
                        }
                    }

                }
                strResultado = Convert.ToString(acumuladorResultado);
            }
            return strResultado;
        }

        /// <summary>
        /// Convierte un numero decimal a binario
        /// </summary>
        /// <param name="numero">numero a convertir</param>
        /// <returns>devuelve el numero decimal en formato string o ,si no pudo, valor invalido</returns>
        public static string DecimalBinario(double numero)
        {
            string strBinario = "";

            //Tomo el valor entero
            int enteroDelNumero = (int)(numero);

            if (enteroDelNumero > 0)
            {
                while (enteroDelNumero > 1)
                {
                    int residuo = enteroDelNumero % 2;
                    strBinario = Convert.ToString(residuo) + strBinario;
                    enteroDelNumero /= 2;
                }
                strBinario = Convert.ToString(enteroDelNumero) + strBinario;

            }
            else
            {
                if (enteroDelNumero == 0)
                {
                    strBinario = "0";
                }
            }

            return strBinario;
        }

        /// <summary>
        /// Convierte un decimal a binario
        /// ayudandose con el metodo DecimalBinario
        /// </summary>
        /// <param name="numero">cadena a convertir</param>
        /// <returns>devuelve valor invalido si no pudo convertir, si pudo, devuelve la cadena convertida</returns>
        public static string DecimalBinario(string numero)
        {
            double auxConversion;
            string strConversion = "Valor invalido";
            if(double.TryParse(numero, out auxConversion))
            {
                //Tomo el valor absoluto
                strConversion = DecimalBinario(Math.Abs(auxConversion));
            }
                
            return strConversion;
        }




    }
}
