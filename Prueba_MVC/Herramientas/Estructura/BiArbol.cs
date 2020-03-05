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
                        Recorrer_Asig(raiz.Hijoder, Nuevo, comparar);   
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
                        Recorrer_Asig(raiz.Hijoizq, Nuevo, comparar);
                    }
                }
            }
        }
        public T Buscar(T valor, Delegate comparar)
        {
            Nodo<T> nodoBuscado = new Nodo<T>();
            nodoBuscado.Valor = valor;
            if (raiz == null)
            {
                return valor;
            }
            else
            {
                int resulcompar = (int)comparar.DynamicInvoke(raiz.Valor, nodoBuscado.Valor);
                if (resulcompar == 0)
                {
                    return raiz.Valor;
                }
                //hijo derecho
                if (resulcompar < 0)
                {
                      return  Recorrer_Busqueda(raiz.Hijoder, nodoBuscado, comparar).Valor;
                    
                }
                //hijo izquierdo
               else
                {
                       return Recorrer_Busqueda(raiz.Hijoizq, nodoBuscado, comparar).Valor;
                }
            }
        }
       

        public void Recorrer_Asig(Nodo<T> dad, Nodo<T> nuevo, Delegate Comparar)
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
                    Recorrer_Asig(dad.Hijoder, nuevo, Comparar);
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
                    Recorrer_Asig(dad.Hijoizq, nuevo, Comparar);
                }
            }
        }
        public Nodo<T> Recorrer_Busqueda(Nodo<T> dad, Nodo<T> buscado, Delegate Comparar)
        {
            int resulcompar=(int)Comparar.DynamicInvoke(dad.Valor, buscado.Valor);
            if (resulcompar == 0)
            {
                return dad;
            }
            if (resulcompar < 0)
            {
                //se debe buscar un valor vacio(recursividad)
                return Recorrer_Busqueda(dad.Hijoder, buscado, Comparar);
            }
            else
            {
                //se debe buscar un valor vacio(recursividad)
                return Recorrer_Busqueda(dad.Hijoizq, buscado, Comparar);
            }
        }

        //public void Eliminar()
        //{
        //    throw new NotImplementedException();


        //}
        // ELIMINAR
        // nIzquierdo -> hijo izquierdo
        //nDerecho -> hijo derecho 
        //Nodo_Arbol -> nodo
        public   Nodo<T> Eliminar(int info, ref Nodo_Arbol t) // t -> raiz 
        {
            if (t != null)
            {
                // Dato menor a la raiz
                if (info < t.dato)
                {
                    Eliminar(info, ref t.nIzquierdo);
                }
                else
                {
                    // Dato mayor a la raiz
                    if (info > t.dato)
                    {
                        Eliminar(info, ref t.nDerecho);
                    }
                    else
                    {
                        Nodo_Arbol NodoELiminar = t; //Nodo ubicado para eliminar

                        if (NodoELiminar.nDerecho == null) //Confirmar que tenga hijo derecho
                        {
                            t = NodoELiminar.nIzquierdo;
                        }
                        else
                        {
                            if (NodoELiminar.nIzquierdo == null)//Se verifica si tiene hijo izquierdo
                            {
                                t = NodoELiminar.nDerecho;
                            }
                            else
                            {
                                if (Alturas(t.nIzquierdo) - Alturas(t.nDerecho) > 0)
                                // Verifica que el hijo pasa a ser la nueva raiz del subarbol
                                {
                                    Nodo_Arbol NodoAux = null;
                                    Nodo_Arbol Auxiliar = t.nDerecho;
                                    bool bandera = false;

                                    //Cambio de valores
                                    while (Auxiliar.nIzquierdo != null)
                                    {
                                        NodoAux = Auxiliar;
                                        Auxiliar = Auxiliar.nIzquierdo;
                                        bandera = true; //Sale hasta cambiar
                                    }

                                    t.dato = Auxiliar.dato; //Nodo temporal
                                    NodoELiminar = Auxiliar;

                                    if (bandera == true)
                                    {
                                        NodoAux.nIzquierdo = Auxiliar.nDerecho;
                                    }
                                    else
                                    {
                                        t.nDerecho = Auxiliar.nDerecho;
                                    }
                                }
                                else
                                {
                                    if (Alturas(t.nDerecho) - Alturas(t.nIzquierdo) == 0)
                                    {
                                        Nodo_Arbol NodoAux = null;
                                        Nodo_Arbol Auxiliar = t.nIzquierdo;
                                        bool bandera = false;

                                        while (Auxiliar.nDerecho != null)
                                        {
                                            NodoAux = Auxiliar;
                                            Auxiliar = Auxiliar.nDerecho;
                                            bandera = true;
                                        }

                                        t.dato = Auxiliar.dato;
                                        NodoELiminar = Auxiliar;

                                        if (bandera == true)
                                        {
                                            NodoAux.nDerecho = Auxiliar.nIzquierdo;
                                        }
                                        else
                                        {
                                            t.nIzquierdo = Auxiliar.nIzquierdo;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            else
            {
                //EL NODO NO EXISTE EN EL ARBOL
            }
        }
    }
}