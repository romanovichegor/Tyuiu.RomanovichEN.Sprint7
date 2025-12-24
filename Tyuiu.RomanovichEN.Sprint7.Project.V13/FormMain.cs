using System.Windows.Forms;
using System.Xml.Linq;
using Tyuiu.RomanovichEN.Sprint7.Project.V13.Lib;
using System.Windows.Forms.DataVisualization.Charting;
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
            try
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
            catch
            {
                MessageBox.Show($"Неправильно введены данные!", "Ошибка при добавлении страны!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void buttonShowChart_REN_Click(object sender, EventArgs e)
        {
            if (_dataService.Countries.Count == 0)
            {
                MessageBox.Show("Нет данных для отображения графика.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var chartForm = new Form();
            chartForm.Text = "Гистограмма населения стран";
            chartForm.Size = new System.Drawing.Size(1800, 600);
            chartForm.StartPosition = FormStartPosition.CenterParent;
            chartForm.MaximizeBox = false;

            var chart = new Chart();
            chart.Size = new System.Drawing.Size(1780, 560);
            chart.Location = new System.Drawing.Point(10, 10);


            var chartArea = new ChartArea();
            chartArea.AxisX.LabelStyle.Angle = -45;
            chartArea.AxisX.LabelStyle.Interval = 1;
            chartArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chart.ChartAreas.Add(chartArea);

            var series = new Series();
            series.Name = "Население";
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "N0";

            foreach (var country in _dataService.Countries)
            {
                series.Points.AddXY(country.Name, country.Population);
            }

            chart.Series.Add(series);

            var legend = new Legend();
            legend.Name = "Legend1";
            chart.Legends.Add(legend);
            chartForm.Controls.Add(chart);

            chartForm.ShowDialog();
        }

        private void buttonShowStats_REN_Click(object sender, EventArgs e)
        {
            if (_dataService.Countries.Count == 0)
            {
                MessageBox.Show("Нет данных о странах.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            long sum = 0;
            long min = long.MaxValue;
            long max = long.MinValue;

            foreach (var country in _dataService.Countries)
            {
                sum += country.Population;
                if (country.Population < min) min = country.Population;
                if (country.Population > max) max = country.Population;
            }

            double avg = (double)sum / _dataService.Countries.Count;

            var statsForm = new FormStats_REN();
            statsForm.SetStats(
                sum.ToString("N0"),
                avg.ToString("N0"),
                min.ToString("N0"),
                max.ToString("N0")
            );
            statsForm.ShowDialog();
        }
    }
}
