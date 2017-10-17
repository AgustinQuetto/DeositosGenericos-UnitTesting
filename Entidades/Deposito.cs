using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Deposito<T>
    {
        private int _capacidadMaxima;
        private List<T> _lista;

        public List<T> Lista { get { return this._lista; } }
        public int Capacidad { get { return this._capacidadMaxima - this._lista.Count; } }

        private Deposito() 
        {
            this._lista = new List<T>();
        }

        public Deposito(int capacidad):this()
        {
            try
            {
                if (capacidad > 50)
                {
                    this._capacidadMaxima = 50;
                    throw new Exception("Supera los 50");
                }
                else if (capacidad < 1)
                {
                    this._capacidadMaxima = 1;
                    throw new Exception("Menor al minimo");
                }
                else
                {
                    this._capacidadMaxima = capacidad;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static bool operator +(Deposito<T> d, T a)
        {
            d._lista.Add(a);
            return true;
        }

        private int GetIndice(T a)
        {
            int i = 0;
            bool esta = false;
            for (i = 0; i < this._lista.Count; i++)
            {
                if (this._lista[i].Equals(a))
                {
                    esta = true;
                    break;
                }
            }

            return esta == true ? i : -1;
        }

        public static bool operator -(Deposito<T> d, T a)
        {
            int i = d.GetIndice(a);
            if (i > -1)
            {
                d._lista.RemoveAt(i);
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Capacidad máxima: " + this._capacidadMaxima.ToString());
            sb.AppendLine("Listado de "+typeof(T).Name+":");
            if (this._lista.Count == 0)
            {
                sb.AppendLine("------------");
            }
            else
            {
                foreach (T item in this._lista)
                {
                    sb.AppendLine(item.ToString());
                }
            }
            return sb.ToString();
        }

        public bool Agregar(T a)
        {
            try {
                if (this.Capacidad == 0)
                {
                    throw new Exception("Se fue a la bosta la capacidad");
                }
                else
                {
                    return this + a;
                }
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }

            return false;
            
        }

        public bool Remover(T a)
        {
            return this - a;
        }
    }
}
