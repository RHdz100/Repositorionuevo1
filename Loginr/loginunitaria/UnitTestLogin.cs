using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;

using Loginr;

namespace loginunitaria
{
    [TestClass]
    public class UnitTestLogin
    {
        [TestMethod]
        public void Conectar()
        {
            Login login = new Login();
            Assert.IsTrue(login.Conexion(), "No se puede conectar");
        }

        //TestVerificacion , TestConectar , TestVerificacion2
        [TestMethod]
        public void Verificacion1()
        {
            Login login = new Login();
           Assert.IsTrue(login.Acceso("rod", "123"));
        }

        [TestMethod]
        public void Verificacion2()
        {
            Login login = new Login();
            Assert.IsFalse(login.Acceso("rew", "125"));
        }
    }
}
