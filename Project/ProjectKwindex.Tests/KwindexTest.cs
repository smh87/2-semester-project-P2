// <copyright file="KwindexTest.cs">Copyright ©  2019</copyright>
using System;
using System.Collections.Generic;
using ConsoleAppCoreNlp;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppCoreNlp.Tests
{
    /// <summary>This class contains parameterized unit tests for Kwindex</summary>
    [PexClass(typeof(Kwindex))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class KwindexTest
    {
        /// <summary>Test stub for KwMain(String, String)</summary>
        [PexMethod]
        public List<string> KwMainTest(
            [PexAssumeUnderTest]Kwindex target,
            string text,
            string wantedPath
        )
        {
            List<string> result = target.KwMain(text, wantedPath);
            return result;
            // TODO: add assertions to method KwindexTest.KwMainTest(Kwindex, String, String)
            
        }
    }
}
