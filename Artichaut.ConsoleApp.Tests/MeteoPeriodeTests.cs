using Artichaut.ConsoleApp.Domain;

namespace Artichaut.ConsoleApp.Tests
{
    [TestClass]
    public class MeteoPeriodeTests
    {
        [TestMethod]
        public void Temperature2m_ShouldBeParsedCorrectly()
        {
            var json = @"{
                ""temperature"": { ""2m"": 293.15 },
                ""pression"": { ""niveau_de_la_mer"": 101325 }
            }";

            var period = Newtonsoft.Json.JsonConvert.DeserializeObject<MeteoPeriode>(json);

            Assert.IsNotNull(period);
            Assert.AreEqual(293.15f, period!.temperature!._2m);
            Assert.AreEqual(101325, period.pression!.niveau_de_la_mer);
        }
    }
}