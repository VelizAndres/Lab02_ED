using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prueba_MVC.Herramientas.Interfaz;

namespace Prueba_MVC.Herramientas.Estructura
{
    public class BiArbol<T> : IArbol<T>
    {
        private Nodo<T> raiz;

        public void Agregar(T valor, Delegate comparar)
        {
            Nodo<T> Nuevo = new Nodo<T>();
            Nuevo.Valor = valor;
            if (raiz == null)
            {
                raiz = Nuevo;
            }
            else
            {
                if ((int)comparar.DynamicInvoke (raiz.Valor,Nuevo.Valor)<0 )
                {
                    if (raiz.Hijoder == null)
                    {
                        raiz.Hijoder = Nuevo;
                    }
                    else
                    {
                        Recorrer(raiz.Hijoder, Nuevo, comparar);   
                    }
                }
                //hijo izquierdo
                else
                {
                    if (raiz.Hijoizq == null)
                    {
                        raiz.Hijoizq = Nuevo;
                    }
                    else
                    {
                        Recorrer(raiz.Hijoizq, Nuevo, comparar);
                    }
                }
            }
        }

        public Nodo<T> move(Nodo<T> Padre, Nodo<T>  NodoAux, Delegate Comparacion)
        {
            if ((int)Comparacion.DynamicInvoke(Padre.Valor, NodoAux.Valor) < 1) { }
            else { }

            return NodoAux;
        }

        public void Buscar()
        {
            throw new NotImplementedException();
        }

        public void Eliminar()
        {
            throw new NotImplementedException();
        }

        public void Recorrer(Nodo<T> dad, Nodo<T> nuevo, Delegate Comparar)
        {
            if ((int)Comparar.DynamicInvoke(dad.Valor,nuevo.Valor)<0)
            {
                if(dad.Hijoder==null)
                {
                    dad.Hijoder = nuevo;
                }
                else
                {
                    //se debe buscar un valor vacio(recursividad)
                    Recorrer(dad.Hijoder, nuevo, Comparar);
                }
            }
            else
            {
                if(dad.Hijoizq==null)
                {
                    dad.Hijoizq = nuevo;
                }
                else
                {
                    //se debe buscar un valor vacio(recursividad)
                    Recorrer(dad.Hijoizq, nuevo, Comparar);
                }
            }
        }
    }
}