using System;

namespace Entidades
{
    public static class Calculadora
    {
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
