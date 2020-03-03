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

        public string Nombre { get => nombre; set => nombre = value; }
        public int Linea { get => linea; set => linea = value; }

 

        public static Comparison<mFarmaco> ComparName = delegate (mFarmaco medic1, mFarmaco medic2)
        {
            return medic1.nombre.CompareTo(medic2.nombre);
        };



    }
}