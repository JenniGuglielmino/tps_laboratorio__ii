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

        public string DecimalBinario(string numero)
        {
            if (Double.TryParse(numero, out double numeroFinal))
            {
                return DecimalBinario(numeroFinal);
            }
            return "Valor Inválido";
        }

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

        public Operando():this(0)
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

        private double ValidarOperando(string strNumero)
        {
            double.TryParse(strNumero, out double numero);
            return numero;
        }

    }
}
