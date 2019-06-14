using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;


namespace pruebasunitarias
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;database=logineje; Uid=root;pwd=; ");
            var user = "rod";
            var pass = "123";
            bool confirm = user == "select user from logineje.log" && pass == "select pass from logineje.log";

        }
    }
}