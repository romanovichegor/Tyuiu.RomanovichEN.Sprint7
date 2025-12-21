using Tyuiu.RomanovichEN.Sprint7.Project.V13.Lib;
namespace Tyuiu.RomanovichEN.Sprint7.Project.V13.Test
{
    public class Tests
    {
        private const string TestFilePath = "test_countries.csv";
        private DataService _dataService;
        public void SetUp()
        {
            _dataService = new DataService();
        }
        public void TearDown()
        {
            if (File.Exists(TestFilePath))
            {
                File.Delete(TestFilePath);
            }
        }

        public void AddCountry_ShouldAddCountryToList()
        {
            var country = new Country
            {
                Name = "Россия",
                Capital = "Москва",
                Area = 17098242,
                IsDeveloped = false,
                Population = 145912025,
                PredominantNationality = "Русские",
                Notes = "Самая большая страна по территории."
            };

            _dataService.AddCountry(country);

            var addedCountry = _dataService.GetCountryByName("Россия");
            Assert.IsNotNull(addedCountry);
            Assert.AreEqual("Россия", addedCountry.Name);
        }

        public void RemoveCountry_ShouldRemoveCountryFromList()
        {
            var country = new Country
            {
                Name = "США",
                Capital = "Вашингтон",
                Area = 9833517,
                IsDeveloped = true,
                Population = 331893745,
                PredominantNationality = "Американцы",
                Notes = "Страна с крупнейшей экономикой."
            };
            _dataService.AddCountry(country);

            _dataService.RemoveCountry("США");

            var removedCountry = _dataService.GetCountryByName("США");
            Assert.IsNull(removedCountry);
        }

        public void SaveData_ShouldSaveCountriesToFile()
        {
            var country = new Country
            {
                Name = "Германия",
                Capital = "Берлин",
                Area = 357022,
                IsDeveloped = true,
                Population = 83240525,
                PredominantNationality = "Немцы",
                Notes = "Экономическая держава Европы."
            };
            _dataService.AddCountry(country);
            _dataService.SaveData();

            _dataService.LoadData();
            var loadedCountry = _dataService.GetCountryByName("Германия");
            Assert.IsNotNull(loadedCountry);
            Assert.AreEqual("Германия", loadedCountry.Name);
        }
    }
}