using CalculApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {
            ResultController rCtrl = new ResultController();

            JObject exp = JObject.FromObject(new { expression = "1+2" });

            IActionResult ArRes = rCtrl.Get(exp);

            Assert.NotNull(ArRes);

            OkObjectResult okObj = ArRes as OkObjectResult;
            JObject resultat = JObject.FromObject(okObj.Value);

            Assert.AreEqual(3, resultat.GetValue("result").ToObject<int>());
        }

        [Test]
        public void Test2()
        {
            ResultController rCtrl = new ResultController();

            JObject exp = JObject.FromObject(new { expression = "1 + 2 + 3 + 4 + 12 + 34" });

            IActionResult ArRes = rCtrl.Get(exp);

            Assert.NotNull(ArRes);

            OkObjectResult okObj = ArRes as OkObjectResult;
            JObject resultat = JObject.FromObject(okObj.Value);

            Assert.AreEqual(56, resultat.GetValue("result").ToObject<int>());
        }
    }
}