using Microsoft.VisualStudio.TestTools.UnitTesting;
using comparer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Compare1.Tests
{
    [TestClass()]
    public class MainCheck1ClassTests
    {
        [TestMethod()]
        public void MainCheck1Test()
        {
            // Arrange
            string words_in = @"C:\Programs\GitHub\P2\P2\Project\Testdata\Dog.txt";
            string expected = "000001";
            string actual;
            // act
            MainCheck1Class Comparetest = new MainCheck1Class();
            actual = Comparetest.MainCheck1(words_in);

            // Assert
            StringAssert.Equals(expected, actual);
                
       
            //Assert.Fail();
        }
    }
}