using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using comparer;
using Project;
using Xunit;

namespace Compare3.Test{
    public class MainCheck3ClassTest {
        [Fact]
        public void MainCheck3Test() {
            MainCheck3Class check = new MainCheck3Class();
            Program pr = new Program();
            //Arrange
            string expected = "can come up with something dog ";
            string path = pr.wantedPath + "Dog.txt";
            string text = File.ReadAllText(path);
            //Act
            string actual = check.MainCheck3(text);
            //Assert
            Console.WriteLine(expected + "\n" + actual);
            Assert.Equal(expected, actual);
        }
    }
}
