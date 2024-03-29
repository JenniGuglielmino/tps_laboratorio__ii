﻿using Entidades.Enumerados;
using System;

namespace Entidades
{
    [Serializable]
    public class PizzaCongelada : Producto, ICanjeable
    {
        private int cantidadDePorciones;
        private int costoEnPuntos;

        public int CostoEnPuntos
        {
            get { return costoEnPuntos; }
            set { costoEnPuntos = value; }
        }

        public int CantidadDePorciones
        {
            get { return cantidadDePorciones; }
            set { cantidadDePorciones = value; }
        }
        /// <summary>
        /// Sobreescribe para esta propiedad, devolviendo porciones del prodcuto como dato en el string
        /// </summary>
        public override string CantidadDeProductoPorUnidad { get { return $"Porciones: {cantidadDePorciones}"; } }

        public PizzaCongelada()
        {
        }

        public PizzaCongelada(int id, string nombre, string descripcion, int cantidad, double precio, float peso, int tipoProductoId, int cantidadDePorciones)
            : base(id, nombre, descripcion, cantidad, precio, peso, tipoProductoId)
        {
            this.CostoEnPuntos = 300;
            this.CantidadDePorciones = cantidadDePorciones;
        }

        public PizzaCongelada(string nombre, string descripcion, int cantidad, double precio, float peso, ETipoProducto tipoProducto, int cantidadDePorciones)
            : base(nombre, descripcion, cantidad, precio, peso, tipoProducto)
        {
            this.CostoEnPuntos = 300;
            this.CantidadDePorciones = cantidadDePorciones;
        }

        public bool SePuedeCanjear(int puntosCliente)
        {
            return puntosCliente >= CostoEnPuntos;
        }
    }
}
