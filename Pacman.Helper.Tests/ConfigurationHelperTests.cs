using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pacman.Helper.Tests
{
         [TestClass]
        public class ConfigurationHelperTests
        {
            [TestMethod]
            public void GetConfigurations_MinimumRange_Pass()
            {
                var sut = ConfigurationHelper.GetConfigurations("MinimumRange");
                Assert.AreEqual(sut, "0");
            }

        public void GetConfigurations_MaximumRange_Pass()
        {
            var sut = ConfigurationHelper.GetConfigurations("MaximumRange");
            Assert.AreEqual(sut, "4");
        }

        [TestMethod]
            public void GetConfigurations_Fail()
            {
                var sut = ConfigurationHelper.GetConfigurations("NoSuchKey");
                Assert.AreEqual(sut, string.Empty);
            }
        }
    
}
