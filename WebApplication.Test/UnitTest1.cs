using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication.Entities;

namespace WebApplication.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CriaCartaoValido()
        {
            CreditCard cc = new CreditCard("4111111111111111");
            Assert.IsTrue(cc.isValid);
        }

        [TestMethod]
        public void CriaCartaoInvalido()
        {
            CreditCard cc = new CreditCard("invalido");
            Assert.IsFalse(cc.isValid);
        }
    }
}
