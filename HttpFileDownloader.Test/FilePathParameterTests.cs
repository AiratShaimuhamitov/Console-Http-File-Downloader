using Microsoft.VisualStudio.TestTools.UnitTesting;
using HttpFileDownloader.Parameters;
using System;

namespace HttpFileDownloader.Test
{
    [TestClass]
    public class FilePathParameterTests
    {
        public string directive;
        public FilePathParameter parameter;

        [TestInitialize]
        public void TestInitialize()
        {
            directive = "-o";
        }

        [TestMethod]
        public void Verify_TrueInput_TrueExpected()
        {
            string value = "mytext.txt";
            bool expected = true;
           
            parameter = new FilePathParameter(directive, value);
 
            bool result = parameter.Verify();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Verify_FalseInput_FalseExpected()
        {
            string value = "mytext.text";
            bool expected = false;
            bool result = true;

            try
            {
                parameter = new FilePathParameter(directive, value);
            } 
            catch(Exception e)
            {
                result = false;
            }

            Assert.AreEqual(expected, result);
        }
    }
}
