using System.Windows.Forms;
using System.Xml.Linq;
using Tyuiu.RomanovichEN.Sprint7.Project.V13.Lib;
using static System.Windows.Forms.MonthCalendar;
namespace Tyuiu.RomanovichEN.Sprint7.Project.V13
{
    public partial class FormMain_REN : Form
    {
        private DataService _dataService;

        public FormMain_REN()
        {
            InitializeComponent();
            _dataService = new DataService();
        }
        private void FormMain_REN_Load(object sender, EventArgs e)
        {

            UpdateCountryList();
        }
        private void UpdateCountryList()
        {
            dataGridViewCountries_REN.Rows.Clear();
            foreach (var country in _dataService.Countries)
            {
                dataGridViewCountries_REN.Rows.Add(country.Name, country.Capital, country.Area, country.IsDeveloped, country.Population, country.PredominantNationality, country.Notes);
            }
        }
        private void buttonAdd_REN_Click(object sender, EventArgs e)
        {
            var country = new Country
            {
                Name = textBoxNameInput_REN.Text,
                Capital = textBoxCapitalInput_REN.Text,
                Area = Convert.ToDouble(textBoxAreaInput_REN.Text),
                IsDeveloped = checkBoxIsDeveloped_REN.Checked,
                Population = Convert.ToInt64(textBoxPopulationInput_REN.Text),
                PredominantNationality = textBoxNation_REN.Text,
                Notes = textBoxNotesInput_REN.Text
            };
            _dataService.AddCountry(country);
            _dataService.SaveData();
            UpdateCountryList();
        }

        private void buttonSave_REN_Click(object sender, EventArgs e)
        {
            _dataService.SaveData();
            MessageBox.Show("Данные успешно сохранены!");
        }

        private void buttonLoad_REN_Click(object sender, EventArgs e)
        {

            if (openFileDialog_REN.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog_REN.FileName;

                try
                {

                    _dataService.LoadDataFromFile(filePath);

                    MessageBox.Show("Данные загружены успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show($"Ошибка при загрузке файла!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            UpdateCountryList();
        }

        private void buttonDelete_REN_Click(object sender, EventArgs e)
        {
            if (dataGridViewCountries_REN.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewCountries_REN.SelectedRows[0];
                var countryName = selectedRow.Cells[0].Value.ToString();
                _dataService.RemoveCountry(countryName);
                _dataService.SaveData();
                UpdateCountryList();
            }
        }

        private void buttonSearch_REN_Click(object sender, EventArgs e)
        {
            string searchName = textBoxSearchInput_REN.Text.Trim();

            if (string.IsNullOrEmpty(searchName))
            {
                textBoxSearchOutput_REN.Text = "Введите название страны для поиска.";
                return;
            }

            var dataService = new DataService();

            dataService.LoadData();

            Country foundCountry = dataService.GetCountryByName(searchName);

            if (foundCountry != null)
            {
                textBoxSearchOutput_REN.Text = $"Найден: {foundCountry.Name}" + Environment.NewLine +
                                  $"Столица: {foundCountry.Capital}" + Environment.NewLine +
                                  $"Площадь: {foundCountry.Area} км²" + Environment.NewLine +
                                  $"Развитая: {foundCountry.IsDeveloped}" + Environment.NewLine +
                                  $"Население: {foundCountry.Population}" + Environment.NewLine +
                                  $"Основная национальность: {foundCountry.PredominantNationality}" + Environment.NewLine +
                                  $"Примечания: {foundCountry.Notes}";
            }
            else
            {
                textBoxSearchOutput_REN.Text = "Страна не найдена.";
            }
        }

        private void buttonHelp_REN_Click(object sender, EventArgs e)
        {
            FormAbout_REN fa = new FormAbout_REN();
            fa.ShowDialog();
        }
    }
}
