using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prueba_MVC.Models;

namespace Prueba_MVC.Models
{
    public class mPedido
    {
        private string name;
        private string direccion;
        private string nit;
        private int[] unidad;
        private List<mFarmaco> pedidos;
        private double total;

        public string Name { get => name; set => name = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Nit { get => nit; set => nit = value; }
        public int[] Unidad { get => unidad; set => unidad = value; }
        public List<mFarmaco> Pedidos { get => pedidos; set => pedidos = value; }
        public double Total { get => total; set => total = value; }
    }
}