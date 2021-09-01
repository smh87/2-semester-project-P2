using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppCoreNlp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project;

namespace ConsoleAppCoreNlp.Tests
{
    [TestClass()]
    public class KwindexTests
    {
        [TestMethod()]
        public void KwMainTest()
        {
            // Arrange
            string text = "The quick fox jumbed over the lazy dog. The quick fox jumbed over the lazy dog. The quick fox jumbed over the lazy dog.";
            var TestKwmain = new Kwindex();
            List<string> expected= new List<string>(){"Cow", "Test" , "test" };
            
            // Act
           List<string> output= TestKwmain.KwMain(text, @"E:\deltefiler\aau\2semster\p2\github\P2\Project\Project\");

            // Assert
            CollectionAssert.AreEqual(expected, output);
            

        }
    }
}