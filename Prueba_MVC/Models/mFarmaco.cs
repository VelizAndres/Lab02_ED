using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prueba_MVC.Herramientas.Estructura;

namespace Prueba_MVC.Models
{
    public class mFarmaco
    {
        private string nombre;
        private int linea;
        private double precio;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Linea { get => linea; set => linea = value; }
        public double Precio { get => precio; set => precio = value; }

        public void Guardar(string name, int posline, double costo)
        {
            Nombre = name;
            Linea = posline;
            Precio = costo;
        }

        public static Comparison<mFarmaco> ComparName = delegate (mFarmaco medic1, mFarmaco medic2)
        {
            return medic1.nombre.CompareTo(medic2.nombre);
        };



    }
}