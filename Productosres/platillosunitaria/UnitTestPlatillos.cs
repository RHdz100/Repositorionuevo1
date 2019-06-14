using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using Productosres;

namespace platillosunitaria
{
    [TestClass]
    public class UnitTestPlatillos
    {
        [TestMethod]
        public void TestConectar()
        {
            Platillos platillo = new Platillos();
            Assert.IsTrue(platillo.platillosconect(), "No se conecto a la bd");
        }

        [TestMethod]
        public void TestInsertar()
        {
            Platillos platillo = new Platillos();
            Assert.IsTrue(platillo.Insertar("hamburguesa", 25));
        }

        [TestMethod]
        public void TestEliminar()
        {
            Platillos platillo = new Platillos();
            Assert.IsTrue(platillo.Eliminar(5));
        }

        [TestMethod]
        public void TestBuscar()
        {
            Platillos platillo = new Platillos();
            Assert.IsTrue(platillo.Buscar("hamburguesa"));
        }

        [TestMethod]
        public void TestActualizar()
        {
            Platillos platillo = new Platillos();
            Assert.IsTrue(platillo.Actualizar("Burrito",20,3));
        }

    }
}
