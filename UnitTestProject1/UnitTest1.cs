using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InicializarLista()
        {
            Deposito<Auto> d = new Deposito<Auto>(5);
            //Verifico que la lista no esté vacía
            Assert.IsNotNull(d.Lista);
        }

        [TestMethod]
        public void EspacioIncorrecto()
        {
            // Corroboro que el espacio no pueda ser mayor a 50
            Deposito<Auto> grande = new Deposito<Auto>(51);
            if (grande.Capacidad != 50)
                Assert.Fail("Espacio disponible mal validado: {0}.", grande.Capacidad);

            // Corroboro que el espacio no pueda ser menor a 1
            Deposito<Auto> chico = new Deposito<Auto>(0);
            Assert.AreNotEqual(chico.Capacidad, 0);
            if (chico.Capacidad != 1)
                Assert.Fail("Espacio disponible mal validado: {0}.", chico.Capacidad);

            // Corroboro si el espacio es el mismo que cargo
            Deposito<Auto> correcto = new Deposito<Auto>(20);
            Assert.AreEqual(correcto.Capacidad, 20);
        }

        [TestMethod]
        public void AgregaDepositoLleno()
        {
            Deposito<Auto> d = new Deposito<Auto>(2);
            Auto a1 = new Auto("Rojo", "Ferrari");
            Auto a2 = new Auto("Amarillo", "Porche");
            Auto a3 = new Auto("Negro", "BMW");

            d.Agregar(a1);
            d.Agregar(a2);
            try
            {
                Assert.IsTrue(d.Agregar(a3));
                Assert.Fail("Debería avisar que el aula está llena.");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(Exception));
            }

        }

        [TestMethod]
        public void AgregaEspacioDisponible()
        {
            Deposito<Auto> d = new Deposito<Auto>(2);
            Auto a1 = new Auto("Rojo", "Ferrari");
            Auto a2 = new Auto("Amarillo", "Porche");

            d.Agregar(a1);
            Assert.AreEqual(d.Capacidad, 1);
            d.Agregar(a2);
            Assert.AreEqual(d.Capacidad, 0);
        }

        //#1- AGREGAR TESTMETHOD QUE VERIFIQUE EL CORRECTO FUNCIONAMIENTO DE '+'

        [TestMethod]
        public void OperadorSuma()
        {
            Deposito<Auto> d = new Deposito<Auto>(2);
            Auto a1 = new Auto("Rojo", "Ferrari");
            Auto a2 = new Auto("Amarillo", "Porche");

            Assert.IsTrue(d+a1);
            Assert.AreEqual(d.Capacidad, 1);
            Assert.IsTrue(d + a2);
            Assert.AreEqual(d.Capacidad, 0);
        }

        //#2- AGREGAR TESTMETHOD QUE VERIFIQUE EL CORRECTO FUNCIONAMIENTO DE 'REMOVER' / '-'

        [TestMethod]
        public void OperadorResta()
        {
            Deposito<Auto> d = new Deposito<Auto>(2);
            Auto a1 = new Auto("Rojo", "Ferrari");
            Auto a2 = new Auto("Amarillo", "Porche");

            Assert.IsTrue(d + a1);
            Assert.IsTrue(d + a2);

            Assert.IsTrue(d - a1);
            Assert.AreEqual(d.Capacidad, 1);
            Assert.IsTrue(d - a2);
            Assert.AreEqual(d.Capacidad, 2);
        }

        [TestMethod]
        public void RemoverEspacioDisponible()
        {
            Deposito<Auto> d = new Deposito<Auto>(2);
            Auto a1 = new Auto("Rojo", "Ferrari");
            Auto a2 = new Auto("Amarillo", "Porche");

            d.Agregar(a1);
            d.Agregar(a2);

            d.Remover(a1);
            Assert.AreEqual(d.Capacidad, 1);
            d.Remover(a2);
            Assert.AreEqual(d.Capacidad, 2);
        }
    }
}
