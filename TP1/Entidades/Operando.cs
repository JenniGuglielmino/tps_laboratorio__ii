using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;
        
        private string Numero { set { this.numero = ValidarOperando(value); } }

        public Operando() : this(0)
        {
        }

        public Operando(double numero)
        {
            this.numero = numero;
        }

        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        /// <summary>
        /// Convierte de binario a decimal 
        /// </summary>
        /// <param name="binario">String binario a convertir</param>
        /// <returns>Retorna un string convertido a decimal</returns>
        public string BinarioDecimal(string binario)
        {
            char[] array = binario.ToCharArray();
            Array.Reverse(array);
            int numero = 0;
            if (EsBinario(binario))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == '1')
                    {
                        numero += (int)Math.Pow(2, i);
                    }
                }
                return numero.ToString();
            }
            return "Valor Inválido";
        }

        /// <summary>
        /// Convierte de decimal a binario
        /// </summary>
        /// <param name="numero">Numero double ingresado a convertir</param>
        /// <returns>Retorna un string con referente al numero binario convertido</returns>
        public string DecimalBinario(double numero)
        {
            string binario = string.Empty;
            int valorAbsoluto = (int)Math.Abs(numero);
            if (valorAbsoluto == 0)
            {
                binario = "0";
            }
            else
            {
                while (valorAbsoluto > 0)
                {
                    binario = (int)valorAbsoluto % 2 + binario;
                    valorAbsoluto = (int)valorAbsoluto / 2;
                }
            }
            return binario;
        }

        /// <summary>
        /// Convierte un decimal a binario
        /// </summary>
        /// <param name="numero">String con el numero a convertir</param>
        /// <returns>Retorna un string con el numero binario</returns>
        public string DecimalBinario(string numero)
        {
            if (Double.TryParse(numero, out double numeroFinal))
            {
                return DecimalBinario(numeroFinal);
            }
            return "Valor Inválido";
        }

        /// <summary>
        /// Verifica si es binario
        /// </summary>
        /// <param name="binario">String a verificar</param>
        /// <returns>Retorna un booleano true si es binario, false si no lo es</returns>
        private bool EsBinario(string binario)
        {
            for (int i = 0; i < binario.Length - 1; i++)
            {
                if (binario[i] != '1' && binario[i] != '0')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Valida el operando ingresado
        /// </summary>
        /// <param name="strNumero">Numero a validar</param>
        /// <returns>Retorna un double resultado de convertir desde un string</returns>
        private double ValidarOperando(string strNumero)
        {
            double.TryParse(strNumero, out double numero);
            return numero;
        }

        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            return double.MinValue;
        }

        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
    }
}
