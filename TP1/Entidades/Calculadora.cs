using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida que el operador ingresado sea valido, sino que sea sumar
        /// </summary>
        /// <param name="operador">Operador ingresado</param>
        /// <returns>Retorna un char que determina la operacion</returns>
        private static char ValidarOperador(char operador)
        {
            char operadorFinal;
            switch (operador)
            {
                case '+':
                    operadorFinal = '+';
                    break;
                case '-':
                    operadorFinal = '-';
                    break;
                case '*':
                    operadorFinal = '*';
                    break;
                case '/':
                    operadorFinal = '/';
                    break;
                default:
                    operadorFinal = '+';
                    break;
            }
            return operadorFinal;
        }
        /// <summary>
        /// Realiza la operacion validando el operador ingresado
        /// </summary>
        /// <param name="num1">Primer numero ingresado</param>
        /// <param name="num2">Segundo numero ingresado</param>
        /// <param name="operador">Operador</param>
        /// <returns>Retorna un double resultado de la operacion</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            char operadorElegido = ValidarOperador(operador);

            double resultado = 0;

            if (num1 != null && num2 != null)
            {
                switch (operadorElegido)
                {
                    case '-':
                        resultado = num1 - num2;
                        break;
                    case '+':
                        resultado = num1 + num2;
                        break;
                    case '*':
                        resultado = num1 * num2;
                        break;
                    case '/':
                        resultado = num1 / num2;
                        break;
                }

            }
            return resultado;
        }


    }
}
