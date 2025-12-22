using System;
using System.IO;
using Tyuiu.RomanovichEN.Sprint7.Project.V13.Lib;
namespace Tyuiu.RomanovichEN.Sprint7.Project.V13.Test
{
    [TestClass]
    public class DataServiceTests
    {
        private const string TestFilePath = "test_countries.csv";
        public void Setup()
        {
            CreateTestFile();
        }
        public void Cleanup()
        {
            if (File.Exists(TestFilePath)) File.Delete(TestFilePath);
        }
        [TestMethod]
        public void AddCountry_ShouldIncreaseCountriesCount()
        {
            var dataService = new DataService();
            var country = new Country { Name = "Германия" };

            dataService.AddCountry(country);

            Assert.AreEqual(1, dataService.Countries.Count);
            Assert.AreEqual("Германия", dataService.Countries[0].Name);
        }

        [TestMethod]
        public void GetCountryByName_ShouldReturnCountryIfExists()
        {
            var dataService = new DataService();
            var country = new Country { Name = "Италия" };
            dataService.AddCountry(country);

            var result = dataService.GetCountryByName("Италия");

            Assert.IsNotNull(result);
            Assert.AreEqual("Италия", result.Name);
        }

        [TestMethod]
        public void RemoveCountry_ShouldRemoveExistingCountry()
        {
            var dataService = new DataService();
            var country = new Country { Name = "Испания" };
            dataService.AddCountry(country);

            dataService.RemoveCountry("Испания");

            Assert.AreEqual(0, dataService.Countries.Count);
        }

        private void CreateTestFile()
        {
            var content = @"Name,Capital,Area,IsDeveloped,Population,PredominantNationality,Notes
Россия,Москва,17075400,True,146000000,русские,Крупнейшая страна мира
Япония,Токио,377972,True,126000000,японцы,Островное государство";
            File.WriteAllText(TestFilePath, content);
        }
    }
}