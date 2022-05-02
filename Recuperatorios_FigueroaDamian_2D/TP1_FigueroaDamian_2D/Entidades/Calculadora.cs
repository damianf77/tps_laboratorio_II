using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {

        /// <summary>
        /// Validara y realizada la operacion pedida entre ambos numeros
        /// </summary>
        /// <param name="num1">objeto de la clase Numero</param>
        /// <param name="num2">objeto de la clase Numero</param>
        /// <param name="operador">cadena con el operador</param>
        /// <returns>devuelve el resultado de la operacion en formato double</returns>
        public static double Operar(Operando num1, Operando num2, string operador)
        {
            double resultado = 0;
            char operadorAValidar = Convert.ToChar(operador);
            string operadorAux = ValidarOperador(operadorAValidar);

            switch(operadorAux)
            {
                case "+":
                    resultado = num1+num2;
                    break;
                case "-":
                    resultado = num1-num2;
                    break;
                case "*":
                    resultado = num1*num2;
                    break;
                case "/":
                    resultado = num1/num2;
                    break;
            }
            return resultado;
        }


        /// <summary>
        /// Valida que el operador sea +,-,/ o *
        /// </summary>
        /// <param name="operador">operador a validar</param>
        /// <returns>retorna el operador en formato string, si no pudo validar devuelve +</returns>
        private static string ValidarOperador(char operador)
        {
            string auxStringOperador;
            auxStringOperador = "+";

            if (operador == '+' || operador == '*' || operador == '/' || operador == '-')
            {
                auxStringOperador = Convert.ToString(operador);
            }

            return auxStringOperador;
        }



    }
}
