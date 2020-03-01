using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_MVC.Herramientas.Interfaz
{
    public abstract class Arbol<T>
    {
        protected abstract void Agregar(T valor);
        protected abstract void Eliminar();
        protected abstract void Buscar(T llave);

    }
}