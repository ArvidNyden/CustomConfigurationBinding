using System.Collections.Generic;
using ArvidDev.Extensions.DependencyInjection.CustomBinding;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace UnitTests
{
    [TestClass]
    public class TestBindings
    {
        [TestMethod]
        public void TestMethod1()
        {
            var config = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("setting-1", "value1"),
                new KeyValuePair<string, string>("Config2", "value2")
            };

            MyConfig objectToBind = BindingHelpers.Bind<MyConfig>(config);

            Assert.AreEqual(objectToBind.Config1, "value1");
            Assert.AreEqual(objectToBind.Config2, "value2");
        }
    }

    public class MyConfig
    {
        [BindToConfiguration("setting-1")]
        public string Config1 { get; set; }
        public string Config2 { get; set; }
    }
}
