using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClusterClass;
using Project;
using System;

namespace UnitTestProject4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MainCluster CluterRef = new MainCluster();
            Program ProgramRef = new Program();

            string[] words_in = { "Algorithms", "attempts", "combinations", "significance", "addition", "symbol", "numeral", "number", "environment", "development" };
            string path = @"E:\my programes\Visual programs\PlagiarismDetector\Project\Project\";
            string[] expected = { "Text2", "Text1", "Text3" };

            string[] actual =  CluterRef.MainClusterCode(words_in, path);

            StringAssert.Equals(expected, actual);
        }
    }
}
